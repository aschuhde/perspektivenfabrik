using Infrastructure.Data.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    private const string DiscriminatorPostfix = "_type";
    public required DbSet<DbPerson> Persons { get; init; }
    public required DbSet<DbUser> Users { get; init; }
    public required DbSet<DbUserRefreshTokens> UserRefreshTokens { get; init; }
    public required DbSet<DbUserRoles> UserRoles { get; init; }
    public required DbSet<DbProject> Projects { get; init; }
    public required DbSet<DbProjectConnection> ProjectsConnections { get; init; }
    public required DbSet<DbOrganization> Organizations { get; init; }
    public required DbSet<DbOrganizationProjectConnection> OrganizationProjectConnections { get; init; }
    public required DbSet<DbContactSpecification> ContactSpecifications { get; init; }
    public required DbSet<DbContactSpecificationProjectConnection> ContactSpecificationsProjectConnections { get; init; }
    public required DbSet<DbDescriptionSpecification> DescriptionSpecifications { get; init; }
    public required DbSet<DbDescriptionSpecificationProjectConnection> DescriptionSpecificationProjectConnections { get; init; }
    public required DbSet<DbDescriptionType> DescriptionTypes { get; init; }
    public required DbSet<DbGraphicsSpecification> GraphicsSpecifications { get; init; }
    public required DbSet<DbGraphicsSpecificationProjectConnection> GraphicsSpecificationProjectConnections { get; init; }
    public required DbSet<DbLocationSpecification> LocationSpecifications { get; init; }
    public required DbSet<DbLocationSpecificationProjectConnection> LocationSpecificationProjectConnections { get; init; }
    public required DbSet<DbLocationSpecificationRequirementConnection> LocationSpecificationRequirementConnections { get; init; }
    public required DbSet<DbMaterialSpecification> MaterialSpecifications { get; init; }
    public required DbSet<DbMaterialSpecificationRequirementConnection> MaterialSpecificationRequirementConnections { get; init; }
    public required DbSet<DbModificationHistory> Histories { get; init; }
    public required DbSet<DbModificationHistoryItem> HistoryItems { get; init; }
    public required DbSet<DbOrganizationConnection> OrganizationConnections { get; init; }
    public required DbSet<DbOrganizationPositionConnection> OrganizationPositionConnections { get; init; }
    public required DbSet<DbPersonProjectOwnerConnection> PersonProjectOwnerConnections { get; init; }
    public required DbSet<DbPersonProjectContributorConnection> PersonProjectContributorConnections { get; init; }
    public required DbSet<DbProjectConnection> ProjectConnections { get; init; }
    public required DbSet<DbProjectTag> ProjectTags { get; init; }
    public required DbSet<DbProjectTagConnection> ProjectTagConnections { get; init; }
    public required DbSet<DbQuantitySpecification> QuantitySpecifications { get; init; }
    public required DbSet<DbQuantitySpecificationRequirementConnection> QuantitySpecificationRequirementConnections { get; init; }
    public required DbSet<DbRequirementSpecification> RequirementSpecifications { get; init; }
    public required DbSet<DbRequirementSpecificationProjectConnection> RequirementSpecificationProjectConnections { get; init; }
    public required DbSet<DbSkillSpecification> SkillSpecifications { get; init; }
    public required DbSet<DbSkillSpecificationRequirementConnection> SkillSpecificationRequirementConnections { get; init; }
    public required DbSet<DbTimeSpecification> TimeSpecifications { get; init; }
    public required DbSet<DbTimeSpecificationProjectConnection> TimeSpecificationProjectConnections { get; init; }
    public required DbSet<DbTimeSpecificationRequirementConnection> TimeSpecificationRequirementConnections { get; init; }
    public required DbSet<DbWorkAmountSpecification> WorkAmountSpecifications { get; init; }
    public required DbSet<DbWorkAmountSpecificationRequirementConnection> WorkAmountSpecificationRequirementConnections { get; init; }
    public required DbSet<DbTag> Tags { get; init; }
    public required DbSet<DbMaterial> Materials { get; init; }
    public required DbSet<DbSkill> Skills { get; init; }
    public required DbSet<DbDescriptionImage> DbDescriptionImages { get; init; }
    public required DbSet<DbFieldTranslation> DbFieldTranslations { get; init; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbPerson>().OwnsOne(x => x.LastModifiedBy, y =>
            {
                y.WithOwner();
                y.HasOne(e => e.Person)
                .WithOne()
                .HasForeignKey<DbEntityPersonLastModifiedByConnection>(e => e.PersonId)
                .IsRequired(false);
        }).OwnsOne(x => x.CreatedBy, y =>
            {
                y.WithOwner();
                y.HasOne(e => e.Person)
                .WithOne()
                .HasForeignKey<DbEntityPersonCreatedByConnection>(e => e.PersonId)
                .IsRequired(false);
            }).HasDiscriminator<string>($"{nameof(DbPerson)}{DiscriminatorPostfix}")
        .HasValue<DbPerson>(nameof(DbPerson))
        .HasValue<DbUser>(nameof(DbUser));
            
        
        modelBuilder.Entity<DbRequirementSpecification>().HasDiscriminator<string>($"{nameof(DbRequirementSpecification)}{DiscriminatorPostfix}")
            .HasValue<DbRequirementSpecification>(nameof(DbRequirementSpecification))
            .HasValue<DbRequirementSpecificationPerson>(nameof(DbRequirementSpecificationPerson))
            .HasValue<DbRequirementSpecificationMaterial>(nameof(DbRequirementSpecificationMaterial))
            .HasValue<DbRequirementSpecificationMoney>(nameof(DbRequirementSpecificationMoney));
        
        modelBuilder.Entity<DbContactSpecification>().HasDiscriminator<string>($"{nameof(DbContactSpecification)}{DiscriminatorPostfix}")
            .HasValue<DbContactSpecification>(nameof(DbContactSpecification))
            .HasValue<DbContactSpecificationPhoneNumber>(nameof(DbContactSpecificationPhoneNumber))
            .HasValue<DbContactSpecificationMailAddress>(nameof(DbContactSpecificationMailAddress))
            .HasValue<DbContactSpecificationPaypal>(nameof(DbContactSpecificationPaypal))
            .HasValue<DbContactSpecificationWebsite>(nameof(DbContactSpecificationWebsite))
            .HasValue<DbContactSpecificationBankAccount>(nameof(DbContactSpecificationBankAccount))
            .HasValue<DbContactSpecificationOrganisationName>(nameof(DbContactSpecificationOrganisationName))
            .HasValue<DbContactSpecificationPersonalName>(nameof(DbContactSpecificationPersonalName))
            .HasValue<DbContactSpecificationPostalAddress>(nameof(DbContactSpecificationPostalAddress));
        
        modelBuilder.Entity<DbLocationSpecification>().HasDiscriminator<string>($"{nameof(DbLocationSpecification)}{DiscriminatorPostfix}")
            .HasValue<DbLocationSpecification>(nameof(DbLocationSpecification))
            .HasValue<DbLocationSpecificationRemote>(nameof(DbLocationSpecificationRemote))
            .HasValue<DbLocationSpecificationRegion>(nameof(DbLocationSpecificationRegion))
            .HasValue<DbLocationSpecificationCoordinates>(nameof(DbLocationSpecificationCoordinates))
            .HasValue<DbLocationSpecificationAddress>(nameof(DbLocationSpecificationAddress));
        
        modelBuilder.Entity<DbTimeSpecification>().HasDiscriminator<string>($"{nameof(DbTimeSpecification)}{DiscriminatorPostfix}")
            .HasValue<DbTimeSpecification>(nameof(DbTimeSpecification))
            .HasValue<DbTimeSpecificationPeriod>(nameof(DbTimeSpecificationPeriod))
            .HasValue<DbTimeSpecificationMoment>(nameof(DbTimeSpecificationMoment))
            .HasValue<DbTimeSpecificationDate>(nameof(DbTimeSpecificationDate))
            .HasValue<DbTimeSpecificationMonth>(nameof(DbTimeSpecificationMonth))
            .HasValue<DbTimeSpecificationDateTime>(nameof(DbTimeSpecificationDateTime));
    }
}
