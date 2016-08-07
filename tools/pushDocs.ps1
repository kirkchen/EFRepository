param([string]$buildFolder, [string]$email, [string]$username, [string]$personalAccessToken)

Write-Host "- Set config settings...."
git config --global user.email $email
git config --global user.name $username
git config --global push.default matching

Write-Host "- Clone gh-pages branch...."
cd "$($buildFolder)\..\"
mkdir gh-pages
git clone --quiet --branch=gh-pages https://$($username):$($personalAccessToken)@github.com/kirkchen/EFRepository.git .\gh-pages\
cd gh-pages
git status

Write-Host "Rename TestDocs index.html to sample.html"
Rename-Item $buildFolder\TestDocs\index.html sample.html

Write-Host "- Copy contents of static-site folder into gh-pages folder...."
copy-item -path $buildFolder\TestDocs\* -Destination $pwd.Path -Recurse -Force

git status
$thereAreChanges = git status | select-string -pattern "Changes not staged for commit:","Untracked files:" -simplematch
if ($thereAreChanges -ne $null) { 
    Write-host "- Committing changes to documentation..."
    git add --all
    git status
    git commit -m "skip ci - static site regeneration"
    git status
    Write-Host "- Push it...."
    git push --quiet
    Write-Host "- Pushed it good!"
} 
else { 
    write-host "- No changes to documentation to commit"
}