using Application.Mapping;
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

    private OrganizationDto CreateTestOrganization(PersonDto personCreator)
    {
        return new OrganizationDto()
        {
            EntityId = Guid.NewGuid(),
            Name = "Organization1",
            CreatedBy = personCreator,
            LastModifiedBy = personCreator,
            History = new ModificationHistoryDto()
            {
                
            }
        };
    }
    private PersonDto CreateTestPersonCreator()
    {
        return new PersonDto()
        {
            EntityId = Guid.NewGuid(),
            Email = "creator@test.com",
            Firstname = "createFirst",
            Lastname = "creatorLast",
        };
    }
    private PersonDto CreateTestPerson1(PersonDto personCreator)
    {
        return new PersonDto()
        {
            Email = "test1@test.test",
            Firstname = "test1",
            Lastname = "test2",
            CreatedBy = personCreator,
            LastModifiedBy = personCreator
        };
    }
    private ProjectDto CreateTestProject1(PersonDto person1, PersonDto personCreator, OrganizationDto organization1)
    {
        return new ProjectDto()
        {
            Contributors =
            [
                person1, personCreator
            ],
            Owner = person1,
            Phase = ProjectPhase.Planning,
            Type = ProjectType.Inspiration,
            Visibility = ProjectVisibility.Internal,
            ConnectedOrganizations = [organization1],
            ContactSpecifications = new[] { new ContactSpecificationDto() },
            DescriptionSpecifications =
            [
                new DescriptionSpecificationDto()
                {
                    Content = new FormattedContent()
                    {
                        RawContentString = "bla",
                    },
                    Type = new DescriptionTypeDto()
                    {
                        Name = "test6",
                        DescriptionTitle = new FormattedTitle()
                        {
                            RawContentString = "testTitle"
                        }
                    },
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                }
            ],
            GraphicsSpecifications =
            [
                new GraphicsSpecificationDto()
                {
                    Content = new GraphicsContent()
                    {
                        Content = [1, 5, 6, 7],
                    },
                    Type = GraphicsType.Additional,
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                }
            ],
            LocationSpecifications =
            [
                new LocationSpecificationDtoAddress()
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
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationDto()
                {
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationDtoCoordinates()
                {
                    Coordinates = new Coordinates()
                    {
                        Lat = 5,
                        Lon = 6.7
                    },
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationDtoRemote()
                {
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                },
                new LocationSpecificationDtoRegion()
                {
                    Region = new Region()
                    {
                        RegionName = "Europe"
                    },
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                }
            ],
            ProjectName = "projectNameTest",
            ProjectTags =
            [
                new ProjectTagDto()
                {
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                },
                new ProjectTagDto()
            ],
            ProjectTitle = new FormattedTitle()
            {
                RawContentString = "testTitle"
            },
            RelatedProjects = [],
            RequirementSpecifications =
            [
                new RequirementSpecificationDto()
                {
                    QuantitySpecification = new QuantitySpecificationDto()
                    {
                        LastModifiedBy = person1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications =
                    [
                        new TimeSpecificationDto()
                        {
                            LastModifiedBy = person1,
                            CreatedBy = personCreator
                        },
                        new TimeSpecificationDtoDate()
                        {
                            Date = DateOnly.FromDateTime(DateTime.Today),
                        },
                        new TimeSpecificationDtoMoment()
                        {

                        },
                        new TimeSpecificationDtoMonth()
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
                        new TimeSpecificationDtoDateTime()
                        {
                            Date = DateTimeOffset.UtcNow
                        }
                    ],
                    TimeSpecificationSameAsProject = false
                },
                new RequirementSpecificationDtoPerson()
                {
                    QuantitySpecification = new QuantitySpecificationDto()
                    {
                        LastModifiedBy = person1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications =
                    [
                        new TimeSpecificationDtoPeriod()
                        {
                            End = new TimeSpecificationDtoMonth()
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
                            Start = new TimeSpecificationDtoDateTime()
                            {
                                Date = DateTimeOffset.UtcNow
                            },
                            LastModifiedBy = person1,
                            CreatedBy = personCreator
                        }
                    ],
                    TimeSpecificationSameAsProject = true,
                    SkillSpecifications =
                    [
                        new SkillSpecificationDto()
                        {
                            LastModifiedBy = person1,
                            CreatedBy = personCreator
                        },
                        new SkillSpecificationDto()
                    ],
                    WorkAmountSpecifications =
                    [
                        new WorkAmountSpecificationDto()
                        {
                            LastModifiedBy = person1,
                            CreatedBy = personCreator
                        }, new WorkAmountSpecificationDto()
                        {
                            
                        }
                    ]
                },
                new RequirementSpecificationDtoMaterial()
                {
                    QuantitySpecification = new QuantitySpecificationDto()
                    {
                        LastModifiedBy = person1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications =
                    [
                        new TimeSpecificationDtoPeriod()
                        {
                            End = new TimeSpecificationDtoMonth()
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
                            Start = new TimeSpecificationDtoDateTime()
                            {
                                Date = DateTimeOffset.UtcNow
                            }
                        }
                    ],
                    TimeSpecificationSameAsProject = true,
                    MaterialSpecifications =
                    [
                        new MaterialSpecificationDto()
                        {
                            LastModifiedBy = person1,
                            CreatedBy = personCreator
                        }
                    ]
                },
                new RequirementSpecificationDtoMoney()
                {
                    QuantitySpecification = new QuantitySpecificationDto()
                    {
                        LastModifiedBy = person1,
                        CreatedBy = personCreator
                    },
                    TimeSpecifications = [],
                    TimeSpecificationSameAsProject = true,
                    MaterialSpecifications =
                    [
                        new MaterialSpecificationDto()
                        {

                        }
                    ],
                    LastModifiedBy = person1,
                    CreatedBy = personCreator
                }
            ],
            TimeSpecifications =
            [
                new TimeSpecificationDtoPeriod()
                {
                    End = new TimeSpecificationDtoMonth()
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
                    Start = new TimeSpecificationDtoDateTime()
                    {
                        Date = DateTimeOffset.UtcNow
                    }
                }
            ],
            ConnectedOrganizationsSameAsOwner = true,
            LastModifiedBy = personCreator,
            CreatedBy = personCreator
        };
    }
    private ProjectDto CreateTestProject2(PersonDto person1, PersonDto personCreator, ProjectDto project1)
    {
        return new ProjectDto()
        {
            Contributors =
            [
                personCreator
            ],
            LastModifiedBy = person1,
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
                new ProjectTagDto()
                {
                },
            ],
            ProjectTitle = new FormattedTitle()
            {
                RawContentString = "testTitle2"
            },
            RelatedProjects = [new ProjectConnectionDto()
            {
                Project = project1,
                Type = ProjectConnectionType.PredecessorProject
            }],
            RequirementSpecifications = [],
            TimeSpecifications = [],
            ConnectedOrganizationsSameAsOwner = true
        };
    }

    private (PersonDto personCreator, PersonDto person1, OrganizationDto organization1, ProjectDto project1, ProjectDto
        project2) CreateTestData()
    {
        var personCreator = CreateTestPersonCreator();
        var person1 = CreateTestPerson1(personCreator);
        var organization1 = CreateTestOrganization(personCreator);
        var project1 = CreateTestProject1(person1, personCreator, organization1);
        var project2 = CreateTestProject2(person1, personCreator, project1);
        return (personCreator, person1, organization1, project1, project2);
    }

    [Test]
    public async Task ProjectsShouldBeEquivalentAfterDbMappingAndMappingBack()
    {
        var (personCreator, person1, organization1, project1, project2) = CreateTestData();
        project1.ToDbProject().ToProject().Should().BeEquivalentTo(project1);
        project2.ToDbProject().ToProject().Should().BeEquivalentTo(project2);
        await Task.Yield();
    }
    
    [Test]
    public async Task ProjectsShouldBeEquivalentAfterApiMappingAndMappingBack()
    {
        var (personCreator, person1, organization1, project1, project2) = CreateTestData();
        project1.ToApiProject().ToProject().Should().BeEquivalentTo(project1);
        project2.ToApiProject().ToProject().Should().BeEquivalentTo(project2);
        await Task.Yield();
    }

    [Test]
    public async Task ProjectsShouldBeEquivalentAfterDbMappingSavingLoadingAndMappingBack()
    {
        var (personCreator, person1, organization1, project1, project2) = CreateTestData();
        
        var dbContext = ScopedServices.GetRequiredService<ApplicationDbContext>();
        var dbProject1 = project1.ToDbProject();
        var dbProject2 = project2.ToDbProject();
        await dbContext.Persons.AddAsync(personCreator.ToDbPerson());
        await dbContext.Persons.AddAsync(person1.ToDbPerson());
        if(project1.History != null)
            await dbContext.Histories.AddAsync(project1.History.ToDbHistory());
        if(project2.History != null)
            await dbContext.Histories.AddAsync(project2.History.ToDbHistory());
        await dbContext.Histories.AddRangeAsync(project1.ConnectedOrganizations.Where(x => x.History != null).Select(x => x.History!.ToDbHistory()));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x.TimeSpecifications.SelectMany(z => z is TimeSpecificationDtoPeriod p ? new []{p.Start, p.End}.Select(y => y.ToDbTimeSpecificationMoment()) : Array.Empty<DbTimeSpecificationMoment>())));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x.TimeSpecifications.Select(y => y.ToDbTimeSpecification())));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.TimeSpecifications.SelectMany(x => x is TimeSpecificationDtoPeriod p ? new []{p.Start, p.End}.Select(y => y.ToDbTimeSpecificationMoment()) : Array.Empty<DbTimeSpecificationMoment>()));
        await dbContext.TimeSpecifications.AddRangeAsync(project1.TimeSpecifications.Select(x => x.ToDbTimeSpecification()));
        await dbContext.LocationSpecifications.AddRangeAsync(project1.LocationSpecifications.Select(x => x.ToDbLocationSpecification()));
        await dbContext.Organizations.AddRangeAsync(project1.ConnectedOrganizations.Select(x => x.ToDbOrganization()));
        await dbContext.ContactSpecifications.AddRangeAsync(project1.ContactSpecifications.Select(x => x.ToDbContactSpecification()));
        await dbContext.DescriptionSpecifications.AddRangeAsync(project1.DescriptionSpecifications.Select(x => x.ToDbDescriptionSpecification()));
        await dbContext.GraphicsSpecifications.AddRangeAsync(project1.GraphicsSpecifications.Select(x => x.ToDbGraphicsSpecification()));
        await dbContext.QuantitySpecifications.AddRangeAsync(project1.RequirementSpecifications.Select(x => x.QuantitySpecification.ToDbQuantitySpecification()));
        await dbContext.MaterialSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationDtoMoney m ? m.MaterialSpecifications.Select(y => y.ToDbMaterialSpecification()) : Array.Empty<DbMaterialSpecification>()));
        await dbContext.MaterialSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationDtoMaterial m ? m.MaterialSpecifications.Select(y => y.ToDbMaterialSpecification()) : Array.Empty<DbMaterialSpecification>()));
        await dbContext.SkillSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationDtoPerson p ? p.SkillSpecifications.Select(y => y.ToDbSkillSpecification()) : Array.Empty<DbSkillSpecification>()));
        await dbContext.WorkAmountSpecifications.AddRangeAsync(project1.RequirementSpecifications.SelectMany(x => x is RequirementSpecificationDtoPerson p ? p.WorkAmountSpecifications.Select(y => y.ToDbWorkAmountSpecification()) : Array.Empty<DbWorkAmountSpecification>()));
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