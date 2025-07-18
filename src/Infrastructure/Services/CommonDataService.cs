using Application.Services;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Data.DbDataTypes;
using Infrastructure.Data.DbEntities;
using Infrastructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public class CommonDataService(ApplicationDbContext dbContext, IServiceProvider serviceProvider) : ICommonDataService
{
    public async Task<int> UpdateTags(ImportValueDto[] importValueDtos, CancellationToken ct)
    {
        var existingTags = await dbContext.Tags.ToArrayAsync(cancellationToken: ct);
        var tagIds = existingTags.Select(x => x.EntityId).ToArray();
        var translationPropertyPath = nameof(DbTag.Name);
        var translations = await dbContext.DbFieldTranslations.Where(x => tagIds.Contains(x.CorrelatedEntityId) && x.PropertyPath == translationPropertyPath).ToArrayAsync(ct);
        var changes = 0;
        foreach (var tag in importValueDtos)
        {
            var existingTag = tag.EntityId != null ? existingTags.FirstOrDefault(x => x.EntityId == tag.EntityId) : null;
            var existingTranslations = existingTag != null ? translations.Where(x => x.CorrelatedEntityId == tag.EntityId).ToArray() : [];
            if (existingTag != null && tag.ToDelete)
            {
                dbContext.Tags.Remove(existingTag);
                if (existingTranslations.Length > 0)
                {
                    dbContext.DbFieldTranslations.RemoveRange(existingTranslations);
                }

                changes++;
                continue;
            }

            if (existingTag != null)
            {
                var hasChange = false;
                if (existingTag.Name != tag.GermanName.Trim() || existingTag.Name != tag.ItalianName.Trim())
                {
                    existingTag.Name = tag.GermanName.Trim();
                    hasChange = true;
                }

                if (UpdateTranslations(existingTranslations, tag.GermanName.Trim(), tag.EntityId!.Value,
                        translationPropertyPath, "de"))
                {
                    hasChange = true;
                }
                if (UpdateTranslations(existingTranslations, tag.ItalianName.Trim(), tag.EntityId!.Value,
                        translationPropertyPath, "it"))
                {
                    hasChange = true;
                }

                if (hasChange)
                {
                    changes++;
                }
                continue;
            }

            if (tag.ToDelete)
            {
                continue;
            }
            
            var newEntityId = tag.EntityId ?? Guid.NewGuid();
            if (newEntityId == Guid.Empty)
            {
                newEntityId = Guid.NewGuid();
            }

            dbContext.Tags.Add(new DbTag()
            {
                Name = tag.GermanName,
                EntityId = newEntityId
            });
            dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
            {
                Content = tag.GermanName,
                LanguageCode = "de",
                CorrelatedEntityId = newEntityId,
                GroupEntityId = newEntityId,
                PropertyPath = translationPropertyPath
            });
            dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
            {
                Content = tag.ItalianName,
                LanguageCode = "it",
                CorrelatedEntityId = newEntityId,
                GroupEntityId = newEntityId,
                PropertyPath = translationPropertyPath
            });
            changes++;
        }

        if (changes > 0)
        {
            await dbContext.SaveChangesAsync(ct);
        }
        return changes;
    }

    private bool UpdateTranslations(DbFieldTranslation[] entityTranslations, string content, Guid correlatedEntityId, string propertyPath, string languageCode)
    {
        var translations = entityTranslations.Where(x => string.Equals(x.LanguageCode, languageCode, StringComparison.InvariantCultureIgnoreCase)).ToArray();
        if (translations.Length == 1)
        {
            var translation = translations.First();
            if (translation.Content != content)
            {
                translation.Content = content;
                return true;
            }

            return false;
        }
        if (translations.Length > 1)
        {
            foreach (var toRemove in translations.Skip(1))
            {
                dbContext.DbFieldTranslations.Remove(toRemove);
            }
            var translation = translations.First();
            if (translation.Content != content)
            {
                translation.Content = content;
            }
            return true;
        }

        dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
        {
            Content = content,
            LanguageCode = languageCode,
            CorrelatedEntityId = correlatedEntityId,
            GroupEntityId = correlatedEntityId,
            PropertyPath = propertyPath
        });
        return true;
    }
    
    public async Task<int> UpdateMaterials(ImportValueDto[] importValueDtos, CancellationToken ct)
    {
        var existingMaterials = await dbContext.Materials.ToArrayAsync(cancellationToken: ct);
        var materialIds = existingMaterials.Select(x => x.EntityId).ToArray();
        var translationPropertyPath = nameof(DbMaterial.Name);
        var translations = await dbContext.DbFieldTranslations.Where(x => materialIds.Contains(x.CorrelatedEntityId) && x.PropertyPath == translationPropertyPath).ToArrayAsync(ct);
        var changes = 0;
        foreach (var material in importValueDtos)
        {
            var existingMaterial = material.EntityId != null ? existingMaterials.FirstOrDefault(x => x.EntityId == material.EntityId) : null;
            var existingTranslations = existingMaterial != null ? translations.Where(x => x.CorrelatedEntityId == material.EntityId).ToArray() : [];
            if (existingMaterial != null && material.ToDelete)
            {
                dbContext.Materials.Remove(existingMaterial);
                if (existingTranslations.Length > 0)
                {
                    dbContext.DbFieldTranslations.RemoveRange(existingTranslations);
                }

                changes++;
                continue;
            }

            if (existingMaterial != null)
            {
                var hasChange = false;
                if (existingMaterial.Name != material.GermanName.Trim() || existingMaterial.Name != material.ItalianName.Trim())
                {
                    existingMaterial.Name = material.GermanName.Trim();
                    hasChange = true;
                }

                if (UpdateTranslations(existingTranslations, material.GermanName.Trim(), material.EntityId!.Value,
                        translationPropertyPath, "de"))
                {
                    hasChange = true;
                }
                if (UpdateTranslations(existingTranslations, material.ItalianName.Trim(), material.EntityId!.Value,
                        translationPropertyPath, "it"))
                {
                    hasChange = true;
                }

                if (hasChange)
                {
                    changes++;
                }
                continue;
            }

            if (material.ToDelete)
            {
                continue;
            }
            
            var newEntityId = material.EntityId ?? Guid.NewGuid();
            if (newEntityId == Guid.Empty)
            {
                newEntityId = Guid.NewGuid();
            }

            dbContext.Materials.Add(new DbMaterial()
            {
                Name = material.GermanName,
                EntityId = newEntityId
            });
            dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
            {
                Content = material.GermanName,
                LanguageCode = "de",
                CorrelatedEntityId = newEntityId,
                GroupEntityId = newEntityId,
                PropertyPath = translationPropertyPath
            });
            dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
            {
                Content = material.ItalianName,
                LanguageCode = "it",
                CorrelatedEntityId = newEntityId,
                GroupEntityId = newEntityId,
                PropertyPath = translationPropertyPath
            });
            changes++;
        }

        if (changes > 0)
        {
            await dbContext.SaveChangesAsync(ct);
        }
        return changes;
    }
    
    public async Task<int> UpdateSkills(ImportValueDto[] importValueDtos, CancellationToken ct)
    {
        var existingSkills = await dbContext.Skills.ToArrayAsync(cancellationToken: ct);
        var skillIds = existingSkills.Select(x => x.EntityId).ToArray();
        var translationPropertyPath = nameof(DbSkill.Name);
        var translations = await dbContext.DbFieldTranslations.Where(x => skillIds.Contains(x.CorrelatedEntityId) && x.PropertyPath == translationPropertyPath).ToArrayAsync(ct);
        var changes = 0;
        foreach (var skill in importValueDtos)
        {
            var existingSkill = skill.EntityId != null ? existingSkills.FirstOrDefault(x => x.EntityId == skill.EntityId) : null;
            var existingTranslations = existingSkill != null ? translations.Where(x => x.CorrelatedEntityId == skill.EntityId).ToArray() : [];
            if (existingSkill != null && skill.ToDelete)
            {
                dbContext.Skills.Remove(existingSkill);
                if (existingTranslations.Length > 0)
                {
                    dbContext.DbFieldTranslations.RemoveRange(existingTranslations);
                }

                changes++;
                continue;
            }

            if (existingSkill != null)
            {
                var hasChange = false;
                if (existingSkill.Name != skill.GermanName.Trim() || existingSkill.Name != skill.ItalianName.Trim())
                {
                    existingSkill.Name = skill.GermanName.Trim();
                    hasChange = true;
                }

                if (UpdateTranslations(existingTranslations, skill.GermanName.Trim(), skill.EntityId!.Value,
                        translationPropertyPath, "de"))
                {
                    hasChange = true;
                }
                if (UpdateTranslations(existingTranslations, skill.ItalianName.Trim(), skill.EntityId!.Value,
                        translationPropertyPath, "it"))
                {
                    hasChange = true;
                }

                if (hasChange)
                {
                    changes++;
                }
                continue;
            }

            if (skill.ToDelete)
            {
                continue;
            }
            
            var newEntityId = skill.EntityId ?? Guid.NewGuid();
            if (newEntityId == Guid.Empty)
            {
                newEntityId = Guid.NewGuid();
            }

            dbContext.Skills.Add(new DbSkill()
            {
                Name = skill.GermanName,
                EntityId = newEntityId
            });
            dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
            {
                Content = skill.GermanName,
                LanguageCode = "de",
                CorrelatedEntityId = newEntityId,
                GroupEntityId = newEntityId,
                PropertyPath = translationPropertyPath
            });
            dbContext.DbFieldTranslations.Add(new DbFieldTranslation()
            {
                Content = skill.ItalianName,
                LanguageCode = "it",
                CorrelatedEntityId = newEntityId,
                GroupEntityId = newEntityId,
                PropertyPath = translationPropertyPath
            });
            changes++;
        }

        if (changes > 0)
        {
            await dbContext.SaveChangesAsync(ct);
        }
        return changes;
    }
    
    public async Task<TagDto[]> GetTags(CancellationToken ct)
    {
        var dbTags = await dbContext.Tags.AsNoTracking().ToArrayAsync(ct);
        var dbTagIds = dbTags.Select(x => x.EntityId).ToArray();
        var fieldTranslations = (await dbContext.DbFieldTranslations.Where(x => dbTagIds.Contains(x.CorrelatedEntityId)).AsNoTracking().ToArrayAsync(ct)).Select(x => x.ToFieldTranslation()).ToArray();
        return dbTags.Select(x => x.ToTag().ApplyTranslations(fieldTranslations)).ToArray();
    }
    public async Task<MaterialDto[]> GetMaterials(CancellationToken ct)
    {
        var dbMaterials = await dbContext.Materials.AsNoTracking().ToArrayAsync(ct);
        var dbMaterialIds = dbMaterials.Select(x => x.EntityId).ToArray();
        var fieldTranslations = (await dbContext.DbFieldTranslations.Where(x => dbMaterialIds.Contains(x.CorrelatedEntityId)).AsNoTracking().ToArrayAsync(ct)).Select(x => x.ToFieldTranslation()).ToArray();
        return dbMaterials.Select(x => x.ToMaterial().ApplyTranslations(fieldTranslations)).ToArray();
    }
    public async Task<SkillDto[]> GetSkills(CancellationToken ct)
    {
        var dbSkills = await dbContext.Skills.AsNoTracking().ToArrayAsync(ct);
        var dbSkillIds = dbSkills.Select(x => x.EntityId).ToArray();
        var fieldTranslations = (await dbContext.DbFieldTranslations.Where(x => dbSkillIds.Contains(x.CorrelatedEntityId)).AsNoTracking().ToArrayAsync(ct)).Select(x => x.ToFieldTranslation()).ToArray();
        return dbSkills.Select(x => x.ToSkill().ApplyTranslations(fieldTranslations)).ToArray(); 
    }

    public async Task<string[]> CleanupDatabase(CancellationToken ct)
    {
        return await CleanupImages(ct);
    }

    private async Task<string[]> CleanupImages(CancellationToken ct)
    {
        var images = await dbContext.DbProjectImages.Where(x => x.Content.MimeType == null).ToArrayAsync(ct);
        var messages = new List<string>();
        var imageService = serviceProvider.GetRequiredService<IImageService>();
        var hasChanges = false;
        foreach (var image in images)
        {
            if (image.Content.Content.Length == 0)
            {
                messages.Add($"Skipped {image.EntityId} due to empty content");
                continue;
            }

            var result = imageService.ProcessImage(image.Content.Content);

            image.Thumbnail = result.ThumbnailImage != null
                ? new DbGraphicsContent
                {
                    Content = result.ThumbnailImage.Content,
                    Width = result.ThumbnailImage.Width,
                    Height = result.ThumbnailImage.Height,
                    MimeType = result.ThumbnailImage.MimeType,
                    FileExtension = result.ThumbnailImage.FileExtension
                }
                : null;
            image.Content = new DbGraphicsContent
            {
                Content = result.LargeImage.Content,
                Width = result.LargeImage.Width,
                Height = result.LargeImage.Height,
                MimeType = result.LargeImage.MimeType,
                FileExtension = result.LargeImage.FileExtension
            };
            hasChanges = true;
            messages.Add($"Updated {image.EntityId}");
        }

        if (hasChanges)
        {
            await dbContext.SaveChangesAsync(ct);
        }
        return messages.ToArray();
    }
}