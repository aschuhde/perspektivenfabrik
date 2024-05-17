using Domain.DataTypes;
using Domain.Entities;
using Domain.Enums;
using FluentAssertions;
using Infrastructure.Data;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Application.FunctionalTests.Mapping;

// ReSharper disable once RedundantUsingDirective
using static Testing;

public sealed class MappingTests : BaseTestFixture
{
    [Test]
    public async Task ProjectShouldBeEquivalentAfterMappingSavingLoadingAndMappingBack()
    {
        var personCreator = new Person()
        {
            EntityId = Guid.NewGuid(),
            Email = "creator@test.com",
            Firstname = "createFirst",
            Lastname = "creatorLast",
        };
        var o1 = new Organization()
        {
            EntityId = Guid.NewGuid(),
            Name = "Organization1",
            CreatedBy = personCreator,
            LastModifiedBy = personCreator,
            History = new ModificationHistory()
            {
                
            }
        };
        var p1 = new Person()
        {
            Email = "test1@test.test",
            Firstname = "test1",
            Lastname = "test2",
            CreatedBy = personCreator,
            LastModifiedBy = personCreator
        };
        var project1 = new Project()
        {
            Contributors =
            [
                p1, personCreator
            ],
            Owner = p1,
            Phase = ProjectPhase.Planning,
            Type = ProjectType.Inspiration,
            Visibility = ProjectVisibility.Internal,
            ConnectedOrganizations = [o1],
            ContactSpecifications = new[] { new ContactSpecification() },
            DescriptionSpecifications =
            [
                new DescriptionSpecification()
                {
                    Content = new FormattedContent()
                    {
                        RawContentString = "bla",
                    },
                    Type = new DescriptionType()
                    {
                        Name = "test6",
                        DescriptionTitle = new FormattedTitle()
                        {
                            RawContentString = "testTitle"
                        }
                    },
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                }
            ],
            GraphicsSpecifications =
            [
                new GraphicsSpecification()
                {
                    Content = new GraphicsContent()
                    {
                        Content = [1, 5, 6, 7],
                    },
                    Type = GraphicsType.Additional,
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                }
            ],
            LocationSpecifications =
            [
                new LocationSpecificationAddress()
                {
                    PostalAddress = new PostalAddress
                    {
                        AddressLine1 = "line1",
                        AddressLine2 = "line2",
                        AddressLine3 = "line3",
                        AddressLine4 = "line4",
                        AddressLine5 = "line5",
                        AddressLine6 = "line6"
                    },
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                },
                new LocationSpecification()
                {
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationCoordinates()
                {
                    Coordinates = new Coordinates()
                    {
                        Lat = 5,
                        Lon = 6.7
                    },
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationRemote()
                {
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationRegion()
                {
                    Region = new Region()
                    {
                        RegionName = "Europe"
                    },
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                }
            ],
            ProjectName = "projectNameTest",
            ProjectTags =
            [
                new ProjectTag()
                {
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                },
                new ProjectTag()
            ],
            ProjectTitle = new FormattedTitle()
            {
                RawContentString = "testTitle"
            },
            RelatedProjects = [],
            RequirementSpecifications =
            [
                new RequirementSpecification()
                {
                    QuantitySpecification = new QuantitySpecification()
                    {
                        LastModifiedBy = p1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications =
                    [
                        new TimeSpecification()
                        {
                            LastModifiedBy = p1,
                            CreatedBy = personCreator
                        },
                        new TimeSpecificationDate()
                        {
                            Date = DateOnly.FromDateTime(DateTime.Today),
                        },
                        new TimeSpecificationMoment()
                        {

                        },
                        new TimeSpecificationMonth()
                        {
                            Month = new Month()
                            {
                                Year = new Year()
                                {
                                    YearNumber = 2001
                                },
                                MonthFromOneToTwelve = 10
                            }
                        },
                        new TimeSpecificationDateTime()
                        {
                            Date = DateTimeOffset.UtcNow
                        }
                    ],
                    TimeSpecificationSameAsProject = false
                },
                new RequirementSpecificationPerson()
                {
                    QuantitySpecification = new QuantitySpecification()
                    {
                        LastModifiedBy = p1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications =
                    [
                        new TimeSpecificationPeriod()
                        {
                            End = new TimeSpecificationMonth()
                            {
                                Month = new Month()
                                {
                                    Year = new Year()
                                    {
                                        YearNumber = 2001
                                    },
                                    MonthFromOneToTwelve = 10
                                }
                            },
                            Start = new TimeSpecificationDateTime()
                            {
                                Date = DateTimeOffset.UtcNow
                            },
                            LastModifiedBy = p1,
                            CreatedBy = personCreator
                        }
                    ],
                    TimeSpecificationSameAsProject = true,
                    SkillSpecifications =
                    [
                        new SkillSpecification()
                        {
                            LastModifiedBy = p1,
                            CreatedBy = personCreator
                        },
                        new SkillSpecification()
                    ],
                    WorkAmountSpecifications =
                    [
                        new WorkAmountSpecification()
                        {
                            LastModifiedBy = p1,
                            CreatedBy = personCreator
                        }, new WorkAmountSpecification()
                        {
                            
                        }
                    ]
                },
                new RequirementSpecificationMaterial()
                {
                    QuantitySpecification = new QuantitySpecification()
                    {
                        LastModifiedBy = p1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications =
                    [
                        new TimeSpecificationPeriod()
                        {
                            End = new TimeSpecificationMonth()
                            {
                                Month = new Month()
                                {
                                    Year = new Year()
                                    {
                                        YearNumber = 2001
                                    },
                                    MonthFromOneToTwelve = 10
                                }
                            },
                            Start = new TimeSpecificationDateTime()
                            {
                                Date = DateTimeOffset.UtcNow
                            }
                        }
                    ],
                    TimeSpecificationSameAsProject = true,
                    MaterialSpecifications =
                    [
                        new MaterialSpecification()
                        {
                            LastModifiedBy = p1,
                            CreatedBy = personCreator
                        }
                    ]
                },
                new RequirementSpecificationMoney()
                {
                    QuantitySpecification = new QuantitySpecification()
                    {
                        LastModifiedBy = p1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications = [],
                    TimeSpecificationSameAsProject = true,
                    MaterialSpecifications =
                    [
                        new MaterialSpecification()
                        {

                        }
                    ],
                    LastModifiedBy = p1,
                    CreatedBy = personCreator
                }
            ],
            TimeSpecifications =
            [
                new TimeSpecificationPeriod()
                {
                    End = new TimeSpecificationMonth()
                    {
                        Month = new Month()
                        {
                            Year = new Year()
                            {
                                YearNumber = 2001
                            },
                            MonthFromOneToTwelve = 10
                        }
                    },
                    Start = new TimeSpecificationDateTime()
                    {
                        Date = DateTimeOffset.UtcNow
                    }
                }
            ],
            ConnectedOrganizationsSameAsOwner = true,
            LastModifiedBy = personCreator,
            CreatedBy = personCreator
        };
        var project2 = new Project()
        {
            Contributors =
            [
                personCreator
            ],
            LastModifiedBy = p1,
            CreatedBy = personCreator,
            Owner = personCreator,
            Phase = ProjectPhase.Idea,
            Type = ProjectType.Idea,
            Visibility = ProjectVisibility.Draft,
            ConnectedOrganizations = [],
            ContactSpecifications = [],
            DescriptionSpecifications = [],
            GraphicsSpecifications = [],
            LocationSpecifications = [],
            ProjectName = "projectNameTest",
            ProjectTags =
            [
                new ProjectTag()
                {
                },
            ],
            ProjectTitle = new FormattedTitle()
            {
                RawContentString = "testTitle2"
            },
            RelatedProjects = [new ProjectConnection()
            {
                Project = project1,
                Type = ProjectConnectionType.PredecessorProject
            }],
            RequirementSpecifications = [],
            TimeSpecifications = [],
            ConnectedOrganizationsSameAsOwner = true
        };

        
        var dbContext = ScopedServices.GetRequiredService<ApplicationDbContext>();
        var dbProject1 = project1.ToDbProject();
        var dbProject2 = project2.ToDbProject();
        await dbContext.Persons.AddAsync(personCreator.ToDbPerson());
        await dbContext.Persons.AddAsync(p1.ToDbPerson());
        if(project1.History != null)
            await dbContext.Histories.AddAsync(project1.History.ToDbHistory());
        if(project2.History != null)
            await dbContext.Histories.AddAsync(project2.History.ToDbHistory());
        await dbContext.Histories.AddRangeAsync(project1.ConnectedOrganizations.Where(x => x.History != null).Select(x => x.History!.ToDbHistory()));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x.TimeSpecifications.SelectMany(z => z is TimeSpecificationPeriod p ? new []{p.Start, p.End}.Select(y => y.ToDbTimeSpecificationMoment()) : Array.Empty<DbTimeSpecificationMoment>())));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x.TimeSpecifications.Select(y => y.ToDbTimeSpecification())));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.TimeSpecifications.SelectMany(x => x is TimeSpecificationPeriod p ? new []{p.Start, p.End}.Select(y => y.ToDbTimeSpecificationMoment()) : Array.Empty<DbTimeSpecificationMoment>()));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.TimeSpecifications.Select(x => x.ToDbTimeSpecification()));
        await dbContext.LocationSpecifications.AddRangeAsync(project1.LocationSpecifications.Select(x => x.ToDbLocationSpecification()));
        await dbContext.Organizations.AddRangeAsync(project1.ConnectedOrganizations.Select(x => x.ToDbOrganization()));
        await dbContext.ContactSpecifications.AddRangeAsync(project1.ContactSpecifications.Select(x => x.ToDbContactSpecification()));
        await dbContext.DescriptionSpecifications.AddRangeAsync(project1.DescriptionSpecifications.Select(x => x.ToDbDescriptionSpecification()));
        await dbContext.GraphicsSpecifications.AddRangeAsync(project1.GraphicsSpecifications.Select(x => x.ToDbGraphicsSpecification()));
        await dbContext.QuantitySpecifications.AddRangeAsync(project1.RequirementSpecifications.Select(x => x.QuantitySpecification.ToDbQuantitySpecification()));
        await dbContext.MaterialSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationMoney m ? m.MaterialSpecifications.Select(y => y.ToDbMaterialSpecification()) : Array.Empty<DbMaterialSpecification>()));
        await dbContext.MaterialSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationMaterial m ? m.MaterialSpecifications.Select(y => y.ToDbMaterialSpecification()) : Array.Empty<DbMaterialSpecification>()));
        await dbContext.SkillSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationPerson p ? p.SkillSpecifications.Select(y => y.ToDbSkillSpecification()) : Array.Empty<DbSkillSpecification>()));
        await dbContext.WorkAmountSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationPerson p ? p.WorkAmountSpecifications.Select(y => y.ToDbWorkAmountSpecification()) : Array.Empty<DbWorkAmountSpecification>()));
        await dbContext.RequirementSpecifications.AddRangeAsync(project1.RequirementSpecifications.Select(x => x.ToDbRequirementSpecification()));
        await dbContext.ProjectTags.AddRangeAsync(project1.ProjectTags.Select(x => x.ToDbProjectTag()));
        await dbContext.ProjectTags.AddRangeAsync(project2.ProjectTags.Select(x => x.ToDbProjectTag()));
        await dbContext.AddAsync(dbProject1);
        await dbContext.AddAsync(dbProject2);
        await dbContext.SaveChangesAsync();

        var dbProject1Loaded = (await dbContext.Projects.Where(x => x.EntityId == dbProject1.EntityId).FirstOrDefaultAsync()) ?? throw new KeyNotFoundException();
        var dbProject2Loaded = await dbContext.Projects.Where(x => x.EntityId == dbProject2.EntityId).FirstOrDefaultAsync() ?? throw new KeyNotFoundException();

        var project1Loaded = dbProject1Loaded.ToProject();
        var project2Loaded = dbProject2Loaded.ToProject();

        project1Loaded.Should().BeEquivalentTo(project1);
        project2Loaded.Should().BeEquivalentTo(project2);
    }
}