# EFRepository

[![Build status](https://ci.appveyor.com/api/projects/status/vriyn5ano6rvqarb?svg=true)](https://ci.appveyor.com/project/kirkchen/efrepository)
[![Code Coverage](http://sonarcovbadge.epicapp.com/?server=sonarqube.com&resource=EFRepository&metrics=coverage&ssl=true)](https://sonarqube.com/overview?id=EFRepository)
[![Technical Debt](https://img.shields.io/sonar/http/sonarqube.com/EFRepository/tech_debt.svg?maxAge=2592000)](https://sonarqube.com/overview?id=EFRepository)
[![NuGet](https://img.shields.io/nuget/v/KirkChen.EFRepository.svg?maxAge=2592000)](https://www.nuget.org/packages/KirkChen.EFRepository/)
[![NuGet Pre Release](https://img.shields.io/nuget/vpre/KirkChen.EFRepository.svg?maxAge=2592000)](https://www.nuget.org/packages/KirkChen.EFRepository/)
[![Gitter](https://badges.gitter.im/efrepository/Lobby.svg)](https://gitter.im/efrepository/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

Generic repository and pattern "Unit of work" for Entity framework

[Read more samples...](https://kirkchen.github.io/EFRepository/sample.html)

## Requirements

* .Net Framework 4.6.1
* EntityFramework 6.1.3

## Features

* [Generic Repository](https://kirkchen.github.io/EFRepository/sample.html?feature=Repositories\GenericRepository.feature)
    * Basic operation
        * Add
        * Add range
        * Get list
        * Get list with condition
        * Get by id
        * Get with condition
        * Update
        * Delete
        * Support generic identity
    * Asynchronous operation
        * Add async
        * Add range async
        * Get list async
        * Get list with condition async
        * Get by id async
        * Get with condition async
        * Update async
        * Delete async   
    * Hooks Supports
        * Nested object save changes
        * [Soft delete](https://kirkchen.github.io/EFRepository/sample.html?feature=Hooks\SoftDelete.feature)
        * [Auto system infomation](https://kirkchen.github.io/EFRepository/sample.html?feature=Hooks\SystemInfo.feature)
        * Audit log
        * Global query filter
* Unit of work

## Quick Start

1. Install nuget package

    ```
    Install-Package KirkChen.EFRepository 
    ```

1. Create data class with interface IEntity<TKey>

    ``` csharp    
    public class MyData : IEntity<int>
    {        
        [Key]
        public int Id { get; set; }
        
        public string Content { get; set; }
    }
    ```

1. Create dbContext

    ``` csharp
    public class MyDbContext: DbContext
    {
        public DbSet<MyData> MyDatas { get; set; }
    }
    ```

1. Create repository for data class

    ``` csharp
    public class MyDataRepository : GenericRepository<int, MyData>, IRepository<int, MyData>
    {
        public MyDataRepository(MyDbContext context)
            : base(context)
        {
            // Enable soft delete
            this.RegisterPostLoadHook(new SoftDeletePostLoadHook<MyData>());
            this.RegisterPostActionHook(new SoftDeletePostActionHook<MyData>());
        }
    }
    ```

1. Use reository

    ``` csharp
    var dbContext = new MyDbContext();
    var repository = new MyDataRepository(dbContext);
    var myData = repository.Get(1);
    ```

## Unit of work    

Using unit of work to handle transaction

``` csharp
using(var dbContext = new MyDbContext())
using(var unitOfWork = new UnitOfWork(dbContext))
{
    var repository = new MyDataRepository(dbContext);
    repository.Add(data);

    var anotherRepository = new OtherDataRepository(dbContext);
    repository.Add(anotherdata);

    unitOfWork.SaveChanges();
}
```

## Roadmap

- [ ] Generic Repository
    - [x] Basic operation
        - [x] Add
        - [x] Add range
        - [x] Get list
        - [x] Get list with condition
        - [x] Get by id
        - [x] Get with condition
        - [x] Update
        - [x] Delete
        - [x] Support generic identity
    - [ ] Asynchronous operation
        - [ ] Add async
        - [ ] Add range async
        - [ ] Get list async
        - [ ] Get list with condition async
        - [ ] Get by id async
        - [ ] Get with condition async
        - [ ] Update async
        - [ ] Delete async        
    - [ ] Hooks Supports
        - [ ] Nested object save changes
        - [x] Soft delete
        - [x] Auto system infomation
        - [ ] Audit log
        - [ ] Global query filter
- [x] Unit of work