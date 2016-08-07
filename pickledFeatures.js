jsonPWrapper ({
  "Features": [
    {
      "RelativeFolder": "Repositories\\GenericRepository.feature",
      "Feature": {
        "Name": "GenericRepository",
        "Description": "As a programmer <br />\r\nIn order to reduce the work of writing repository <br />\r\nI would like to create a GenericRepository to process database related logic <br />\r\n\r\n1. Create data class inherits **IEntity**\r\n\r\n\t\tpublic class TestData : IEntity<int>\r\n\t\t{        \r\n\t\t\t[Key]\r\n\t\t\tpublic int Id { get; set; }\r\n        \r\n\t        public string Content { get; set; }\r\n\t\t}\r\n\r\n1. Create repository inherits **Generic repository**\r\n\r\n\t\tpublic class TestRepository : GenericRepository<int, TestData>, IRepository<int, TestData>\r\n\t\t{        \r\n\t\t\tpublic TestRepository(TestDbContext context)\r\n\t\t\t\t: base(context)\r\n\t\t\t{\r\n\t\t\t}\r\n\t\t}\r\n\r\n1. Use repository\r\n\r\n\t\tusing(var dbContext = new MyDbContext())\r\n\t\t{\r\n\t\t\tvar repository = new TestRepository(dbContext);\r\n\t\t\t\r\n\t\t\t//// Support basic CRUD operation\r\n\t\t\tvar data = repository.Get(1)\r\n\t\t\trepository.Add(myData);\r\n\t\t\trepository.Update(myData);\r\n\t\t\trepository.Delete(1)\r\n\t\t}\r\n\r\nBelow are some sceranrios for **Generic repository**",
        "FeatureElements": [
          {
            "Name": "Add data into database should be success",
            "Slug": "add-data-into-database-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I have test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository to add data",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Add datalist into database should be success",
            "Slug": "add-datalist-into-database-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I have test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository to add datalist",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get datalist from database should be success",
            "Slug": "get-datalist-from-database-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data list from database",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get datalist from database with condition content should contains \"2\" should be success",
            "Slug": "get-datalist-from-database-with-condition-content-should-contains-2-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "test datas content field should contains \"2\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data list with condition from database",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get data from database should be success",
            "Slug": "get-data-from-database-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data from database by id \"1\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get data from database with condition content should contains \"2\" should be success",
            "Slug": "get-data-from-database-with-condition-content-should-contains-2-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "test datas content field should contains \"2\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data from database with conditon",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Update data which is exists in database should be success",
            "Slug": "update-data-which-is-exists-in-database-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "the data I want to update is",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData Modified"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository update data",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData Modified"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Delete data which is exists in database should be success",
            "Slug": "delete-data-which-is-exists-in-database-should-be-success",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository delete data with id \"1\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": [
          "@Repository"
        ]
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "Hooks\\SystemInfo.feature",
      "Feature": {
        "Name": "SystemInfo",
        "Description": "As a programmer <br />\r\nIn order to auto assign required system information when insert or update data <br />\r\nI would like to use use system info hook to handle assign system infomation logic <br />\r\n\r\n1. Create data class inherits **ISystemInfo**\r\n\t\t\r\n\t\tpublic class SoftDeleteData : IEntity<int>, ISoftDelete\r\n\t\t{        \r\n\t\t\t[Key]\r\n\t\t\tpublic int Id { get; set; }\r\n       \r\n\t\t\tpublic string Content { get; set; }\r\n      \r\n\t\t\tpublic DateTime CreatedAt { get; set; }\r\n\r\n\t        public string CreatedBy { get; set; }\r\n\r\n\t\t\tpublic DateTime UpdatedAt { get; set; }\r\n\r\n\t\t\tpublic string UpdatedBy { get; set; }\r\n\t\t}\t\r\n\r\n1. Create **UserHelper** class to get current username in your system\r\n\r\n\t\tpublic class UserHelper: IUserHelper\r\n\t\t{\r\n\t\t\tpublic string GetUserName()\r\n\t\t\t{\r\n\t\t\t\t//// Implement your system user name logic\r\n\t\t\t\treturn HttpContext.Current.User.Name;\r\n\t\t\t}\r\n\t\t}\r\n\r\n1. Create repository inherits **Generic repository** and register **System info hook**\r\n\r\n\t\tpublic class SystemInfoRepository : GenericRepository<int, SystemInfoData>, IRepository<int, SystemInfoData>\r\n\t\t{        \r\n\t\t\tpublic SystemInfoRepository(MyDbContext context)\r\n\t\t\t\t: base(context)\r\n\t\t\t{\r\n\t\t\t\tthis.Repository.RegisterPostActionHook(new SystemInfoPostActionHook<SystemInfoData>(new UserHelper(), new DatetimeHelper()));\r\n\t\t\t}\r\n\t\t}\r\n\r\n1. Use repository\r\n\r\n\t\tusing(var dbContext = new MyDbContext())\r\n\t\t{\r\n\t\t\tvar repository = new SoftDeleteRepository(dbContext);\r\n\r\n\t\t\t//// Will auto update required system info field\r\n\t\t\trepository.Add(myData);\r\n\r\n\t\t\tor\r\n\r\n\t\t\t//// Will auto update required system info field\r\n\t\t\trepository.Update(myData);\r\n\t\t}\r\n\r\nBelow are some sceranrios for **System info hook**",
        "FeatureElements": [
          {
            "Name": "Add data into database should be success and auto assign system required infomation",
            "Slug": "add-data-into-database-should-be-success-and-auto-assign-system-required-infomation",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I have systemInfo datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Current user is \"John\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Current datetime is \"2016/08/05 16:00:00\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register system info hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository to add data",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "CreatedAt",
                    "CreatedBy",
                    "UpdatedAt",
                    "UpdatedBy"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Add datalist into database should be success and auto assign system required infomation",
            "Slug": "add-datalist-into-database-should-be-success-and-auto-assign-system-required-infomation",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "I have systemInfo datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData"
                    ],
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Current user is \"John\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Current datetime is \"2016/08/05 16:00:00\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register system info hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository to add datalist",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "CreatedAt",
                    "CreatedBy",
                    "UpdatedAt",
                    "UpdatedBy"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Update data which is exists in database should be success and auto assign system required infomation",
            "Slug": "update-data-which-is-exists-in-database-should-be-success-and-auto-assign-system-required-infomation",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has systemInfo datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "CreatedAt",
                    "CreatedBy",
                    "UpdatedAt",
                    "UpdatedBy"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "the data I want to update is",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "CreatedAt",
                    "CreatedBy",
                    "UpdatedAt",
                    "UpdatedBy"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData Modified",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Current user is \"David\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Current datetime is \"2016/08/06 09:00:00\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register system info hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository update data",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "CreatedAt",
                    "CreatedBy",
                    "UpdatedAt",
                    "UpdatedBy"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData Modified",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/06 09:00:00",
                      "David"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "2016/08/05 16:00:00",
                      "John",
                      "2016/08/05 16:00:00",
                      "John"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": [
          "@Hook"
        ]
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    },
    {
      "RelativeFolder": "Hooks\\SoftDelete.feature",
      "Feature": {
        "Name": "SoftDelete",
        "Description": "As a programmer  <br />\r\nIn order to update IsDelete property in data class instead of delete data in the database\t<br />\r\nI would like to use soft delete hook to handle soft delete logic <br />\r\n\r\n1. Create data class inherits **ISoftDelete**\r\n\t\t\r\n\t\tpublic class SoftDeleteData : IEntity<int>, ISoftDelete\r\n\t\t{        \r\n\t\t\t[Key]\r\n\t\t\tpublic int Id { get; set; }\r\n       \r\n\t\t\tpublic string Content { get; set; }\r\n      \r\n\t\t\tpublic bool IsDelete { get; set; }\r\n\t\t}\t\r\n\r\n1. Create repository inherits **Generic repository** and register **Soft delete hook**\r\n\r\n\t\tpublic class SoftDeleteRepository : GenericRepository<int, SoftDeleteData>, IRepository<int, SoftDeleteData>\r\n\t\t{        \r\n\t\t\tpublic SoftDeleteRepository(MyDbContext context)\r\n\t\t\t\t: base(context)\r\n\t\t\t{\r\n\t\t\t\tthis.RegisterPostLoadHook(new SoftDeletePostLoadHook<MyData>());\r\n\t\t\t\tthis.RegisterPostActionHook(new SoftDeletePostActionHook<MyData>());\r\n\t\t\t}\r\n\t\t}\r\n\r\n1. Use repository\r\n\r\n\t\tusing(var dbContext = new MyDbContext())\r\n\t\t{\r\n\t\t\tvar repository = new SoftDeleteRepository(dbContext);\r\n\r\n\t\t\t//// Will update IsDelete to true\r\n\t\t\trepository.Delete(1);\r\n\r\n\t\t\tor\r\n\r\n\t\t\t//// Will only get data with IsDelete=false\r\n\t\t\tvar myData = repository.Get(1);\r\n\t\t}\r\n\r\nBelow are some sceranrios for **Soft delete hook**",
        "FeatureElements": [
          {
            "Name": "Get datalist from database should filter IsDelete=true if data is soft delete",
            "Slug": "get-datalist-from-database-should-filter-isdeletetrue-if-data-is-soft-delete",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has soft delete datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "IsDelete"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "true"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "false"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register soft delete hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data list from database",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get datalist from database with condition content should contains \"2\" should filter IsDelete=true if data is soft delete",
            "Slug": "get-datalist-from-database-with-condition-content-should-contains-2-should-filter-isdeletetrue-if-data-is-soft-delete",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has soft delete datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "IsDelete"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "true"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "false"
                    ],
                    [
                      "3",
                      "TestData 2",
                      "true"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "test datas content field should contains \"2\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register soft delete hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data list with condition from database",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "2",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get data from database should filter IsDelete=true if data is soft delete",
            "Slug": "get-data-from-database-should-filter-isdeletetrue-if-data-is-soft-delete",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has soft delete datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "IsDelete"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "true"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "false"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register soft delete hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data from database by id \"1\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be empty",
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Get data from database with condition content should contains \"2\" should filter IsDelete=true if data is soft delete",
            "Slug": "get-data-from-database-with-condition-content-should-contains-2-should-filter-isdeletetrue-if-data-is-soft-delete",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has soft delete datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "IsDelete"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "true"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "true"
                    ],
                    [
                      "3",
                      "TestData 2",
                      "false"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "test datas content field should contains \"2\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register soft delete hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository get data from database with conditon",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "the data list I get should be",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content"
                  ],
                  "DataRows": [
                    [
                      "3",
                      "TestData 2"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          },
          {
            "Name": "Delete data will be replaced by update IsDelete field",
            "Slug": "delete-data-will-be-replaced-by-update-isdelete-field",
            "Description": "",
            "Steps": [
              {
                "Keyword": "Given",
                "NativeKeyword": "Given ",
                "Name": "database has soft delete datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "IsDelete"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "false"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "false"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "Register soft delete hook in generic repository",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "When",
                "NativeKeyword": "When ",
                "Name": "I use generic repository delete data with id \"1\"",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "And",
                "NativeKeyword": "And ",
                "Name": "I save the changes",
                "StepComments": [],
                "AfterLastStepComments": []
              },
              {
                "Keyword": "Then",
                "NativeKeyword": "Then ",
                "Name": "database should exists test datas",
                "TableArgument": {
                  "HeaderRow": [
                    "Id",
                    "Content",
                    "Is delete"
                  ],
                  "DataRows": [
                    [
                      "1",
                      "TestData",
                      "true"
                    ],
                    [
                      "2",
                      "TestData 2",
                      "false"
                    ]
                  ]
                },
                "StepComments": [],
                "AfterLastStepComments": []
              }
            ],
            "Tags": [],
            "Result": {
              "WasExecuted": false,
              "WasSuccessful": false
            }
          }
        ],
        "Result": {
          "WasExecuted": false,
          "WasSuccessful": false
        },
        "Tags": [
          "@Hook"
        ]
      },
      "Result": {
        "WasExecuted": false,
        "WasSuccessful": false
      }
    }
  ],
  "Summary": {
    "Tags": [
      {
        "Tag": "@Repository",
        "Total": 8,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 8
      },
      {
        "Tag": "@Hook",
        "Total": 8,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 8
      }
    ],
    "Folders": [
      {
        "Folder": "Repositories",
        "Total": 8,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 8
      },
      {
        "Folder": "Hooks",
        "Total": 8,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 8
      }
    ],
    "NotTestedFolders": [
      {
        "Folder": "Repositories",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      },
      {
        "Folder": "Hooks",
        "Total": 0,
        "Passing": 0,
        "Failing": 0,
        "Inconclusive": 0
      }
    ],
    "Scenarios": {
      "Total": 16,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 16
    },
    "Features": {
      "Total": 3,
      "Passing": 0,
      "Failing": 0,
      "Inconclusive": 3
    }
  },
  "Configuration": {
    "GeneratedOn": "7 August 2016 15:08:01"
  }
});