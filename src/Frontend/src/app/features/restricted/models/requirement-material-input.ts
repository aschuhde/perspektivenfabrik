import { ApplicationModelsApiModelsApiRequirementSpecificationMaterial } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { SelectOptionMaterial } from "../../../shared/models/select-option-material";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {SelectOption} from "../../../shared/models/select-option";
import {ObjectCreator} from "../../../shared/tools/object-creator";
import {TranslationValue} from "../../../shared/models/translation-value";
import {Language} from "../../../core/types/general-types";

export class RequirementMaterialInput{
    entityId: string | null = null;
    quantitySpecificationEntityId: string | null = null;
    quantitySpecificationValue: string | null = null;
    quantitySpecificationValueTranslations: TranslationValue[] = []; 
    selectedMaterials: SelectOptionMaterial[] = [];  
    requirementTimeIsIdenticalToProjectTime: boolean = true
    requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
    requirementLocationIsIdenticalToProjectLocation: boolean = true
    requirementLocations: LocationInput[] = [new LocationInput()];
    
  toRequirementMaterialSpecifications(mainLanguage: Language): ApplicationModelsApiModelsApiRequirementSpecificationMaterial {
    return ObjectCreator.Create<ApplicationModelsApiModelsApiRequirementSpecificationMaterial>({
      classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material,
      entityId: this.entityId ?? undefined,
      quantitySpecification: {
        value: TranslationValue.getTranslationIfExist(this.quantitySpecificationValue ?? "", this.quantitySpecificationValueTranslations, mainLanguage),
        entityId: this.quantitySpecificationEntityId ?? undefined,
        valueTranslations: TranslationValue.toApiTranslationValues(this.quantitySpecificationValueTranslations)
      },
      materialSpecifications: this.selectedMaterials.map(x => {
        return {
          name: TranslationValue.getTranslationIfExist(x.value,x.valueTranslations, mainLanguage),
          nameTranslations: TranslationValue.toApiTranslationValues(x.valueTranslations),
          entityId: x.entityId ?? undefined,
          title: {
            rawContentString: TranslationValue.getTranslationIfExist(x.text,x.textTranslations, mainLanguage),
            contentTranslations: TranslationValue.toApiTranslationValues(x.textTranslations)
          },
          description: {
            rawContentString: TranslationValue.getTranslationIfExist(x.description,x.descriptionTranslations, mainLanguage),
            contentTranslations: TranslationValue.toApiTranslationValues(x.descriptionTranslations)
          },
          amountValue: TranslationValue.getTranslationIfExist(x.amount,x.amountTranslations, mainLanguage),
          amountValueTranslations: TranslationValue.toApiTranslationValues(x.amountTranslations)
        }
      }),
      timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,
      locationSpecificationsSameAsProject: this.requirementLocationIsIdenticalToProjectLocation,
      locationSpecifications: this.requirementLocationIsIdenticalToProjectLocation ? [] : this.requirementLocations.map(x => x.toLocationSpecification(mainLanguage)).filter(x => !!x),
      timeSpecifications:  this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)
    });
  }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationMaterial, mainLanguage: Language) {
    const result = new RequirementMaterialInput();
    result.entityId = requirementSpecification.entityId ?? null;
    result.quantitySpecificationValueTranslations = TranslationValue.arrayFromApiTranslationValues(requirementSpecification.quantitySpecification?.valueTranslations ?? []);
    result.quantitySpecificationValue = TranslationValue.getTranslationIfExist(requirementSpecification.quantitySpecification?.value ?? "", result.quantitySpecificationValueTranslations, mainLanguage);
    result.quantitySpecificationEntityId = requirementSpecification.quantitySpecification?.entityId ?? null;
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementLocationIsIdenticalToProjectLocation = requirementSpecification.locationSpecificationsSameAsProject ?? true;
    result.requirementLocations = requirementSpecification.locationSpecifications?.map(x => LocationInput.fromLocationSpecification(x, mainLanguage))?.filter(x => !!x) ?? [];
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.selectedMaterials = requirementSpecification.materialSpecifications?.map(x => {
      const valueTranslations = TranslationValue.arrayFromApiTranslationValues(x.nameTranslations ?? []);
      const textTranslations= TranslationValue.arrayFromApiTranslationValues(x.title?.contentTranslations ?? []);
      const descriptionTranslations= TranslationValue.arrayFromApiTranslationValues(x.description?.contentTranslations ?? []);
      const amountTranslations= TranslationValue.arrayFromApiTranslationValues(x.amountValueTranslations ?? []);
      return new SelectOptionMaterial({
        value: TranslationValue.getTranslationIfExist(x.name ?? "", valueTranslations, mainLanguage),
        text: TranslationValue.getTranslationIfExist(x.title?.rawContentString ?? "", textTranslations, mainLanguage),
        amount: TranslationValue.getTranslationIfExist(x.amountValue ?? "", descriptionTranslations, mainLanguage),
        description: TranslationValue.getTranslationIfExist(x.description?.rawContentString ?? "", amountTranslations, mainLanguage),
        entityId: x.entityId ?? null,
        valueTranslations: valueTranslations,
        textTranslations: textTranslations,
        descriptionTranslations: descriptionTranslations,
        amountTranslations: amountTranslations
      })
    }).filter(x => !!x.value) ?? [];
    return result;
  }
}