using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Data.DbLoading;

public static class DbProjectLoadingExtensions
{
    public static IQueryable<DbProject> IncludeRelatedProjects(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.RelatedProjects!).ThenInclude(x => x.RelatedProject);
    
    public static IQueryable<DbProject> IncludeDescriptionSpecifications(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.DescriptionSpecifications!).ThenInclude(x => x.DescriptionSpecification!).ThenInclude(x => x.Type);
    
    public static IQueryable<T> IncludeHistory<T>(
        this IQueryable<T> query) where T: DbEntity =>
        query.Include(x => x.History!).ThenInclude(x => x.History!).ThenInclude(x => x.HistoryItems);
    
    public static IQueryable<DbProject> IncludeContactSpecifications(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.ContactSpecifications!).ThenInclude(x => x.ContactSpecification);
    
    public static IQueryable<DbProject> IncludeGraphicsSpecifications(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.GraphicsSpecifications!).ThenInclude(x => x.GraphicsSpecification);
    
    public static IQueryable<DbProject> IncludeConnectedOrganizations(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.ConnectedOrganizations!).ThenInclude(x => x.Organization);
    
    public static IQueryable<DbProject> IncludeOwner(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.Owner!).ThenInclude(x => x.Person);
    
    public static IQueryable<DbProject> IncludeContributors(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.Contributors!).ThenInclude(x => x.Person);
    
    public static IQueryable<DbProject> IncludeProjectTags(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.ProjectTags!).ThenInclude(x => x.ProjectTag);
    
    public static IQueryable<DbProject> IncludeLocationSpecifications(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.LocationSpecifications!).ThenInclude(x => x.LocationSpecification);
    
    public static IQueryable<DbProject> IncludeTimeSpecifications(
        this IQueryable<DbProject> query) =>
        query.Include(x => x.TimeSpecifications!).ThenInclude(x => x.TimeSpecification!)
            .ThenInclude(x => (x as DbTimeSpecificationPeriod)!.Start).ThenInclude(x => x.Moment)
            .Include(x => x.TimeSpecifications!).ThenInclude(x => x.TimeSpecification!)
            .ThenInclude(x => (x as DbTimeSpecificationPeriod)!.End).ThenInclude(x => x.Moment);
    
    public static IIncludableQueryable<DbProject, DbRequirementSpecification> IncludeRequirementSpecificationsInner(
        this IQueryable<DbProject> query) =>
        query
            .Include(x => x.RequirementSpecifications!).ThenInclude(x => x.RequirementSpecification!);

    public static IQueryable<DbProject> IncludeRequirementSpecifications(
        this IQueryable<DbProject> query) =>
        query.IncludeRequirementSpecificationsInner().ThenInclude(x => x.TimeSpecifications!)
            .ThenInclude(x => x.TimeSpecification!).ThenInclude(x => (x as DbTimeSpecificationPeriod)!.Start)
            .ThenInclude(x => x.Moment)
            .IncludeRequirementSpecificationsInner().ThenInclude(x => x.TimeSpecifications!)
            .ThenInclude(x => x.TimeSpecification!).ThenInclude(x => (x as DbTimeSpecificationPeriod)!.End)
            .ThenInclude(x => x.Moment)
            .IncludeRequirementSpecificationsInner().ThenInclude(x => x.QuantitySpecification!)
            .ThenInclude(x => x.QuantitySpecification!)
            .IncludeRequirementSpecificationsInner()
            .ThenInclude(x => (x as DbRequirementSpecificationMaterial)!.LocationSpecifications!)
            .ThenInclude(x => x.LocationSpecification)
            .IncludeRequirementSpecificationsInner()
            .ThenInclude(x => (x as DbRequirementSpecificationMaterial)!.MaterialSpecifications!)
            .ThenInclude(x => x.MaterialSpecification)
            .IncludeRequirementSpecificationsInner()
            .ThenInclude(x => (x as DbRequirementSpecificationPerson)!.LocationSpecifications!)
            .ThenInclude(x => x.LocationSpecification)
            .IncludeRequirementSpecificationsInner()
            .ThenInclude(x => (x as DbRequirementSpecificationPerson)!.SkillSpecifications!)
            .ThenInclude(x => x.SkillSpecification)
            .IncludeRequirementSpecificationsInner()
            .ThenInclude(x => (x as DbRequirementSpecificationPerson)!.WorkAmountSpecification!)
            .ThenInclude(x => x.WorkAmountSpecification);

    public static IQueryable<DbProject> IncludeFull(
        this IQueryable<DbProject> query) =>
        query.IncludeRelatedProjects().IncludeDescriptionSpecifications().IncludeHistory()
            .IncludeContactSpecifications().IncludeGraphicsSpecifications().IncludeRequirementSpecifications()
            .IncludeConnectedOrganizations().IncludeOwner().IncludeContributors().IncludeProjectTags()
            .IncludeLocationSpecifications().IncludeTimeSpecifications();

}