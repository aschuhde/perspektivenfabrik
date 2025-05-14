import { ApplicationModelsApiModelsApiRequirementSpecificationMoney } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { ProjectTimeInput } from "./project-time-input";
import {LocationInput} from "./location-input";
import {SelectOptionMaterial} from "../../../shared/models/select-option-material";
import {TranslationValue} from "../../../shared/models/translation-value";
import {Language} from "../../../core/types/general-types";

export class RequirementMoneyInput{
    entityId: string | null = null;
    quantitySpecificationEntityId: string | null = null;
    amountOfMoney: string = "";  
    amountOfMoneyTranslations: TranslationValue[] = [];
    requirementTimeIsIdenticalToProjectTime: boolean = true;
    requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
      
    toRequirementMoneySpecification(mainLanguage: Language): ApplicationModelsApiModelsApiRequirementSpecificationMoney {
      return {
        classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money,
          entityId: this.entityId ?? undefined,
        timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,                      
        quantitySpecification: {
            value: TranslationValue.getTranslationIfExist(this.amountOfMoney, this.amountOfMoneyTranslations, mainLanguage),
            valueTranslations: TranslationValue.toApiTranslationValues(this.amountOfMoneyTranslations),
            entityId: this.quantitySpecificationEntityId ?? undefined
        },     
        timeSpecifications: this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)
      };
    }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationMoney, mainLanguage: Language) {
    const result = new RequirementMoneyInput();
    result.entityId = requirementSpecification.entityId ?? null;
    result.amountOfMoneyTranslations = TranslationValue.arrayFromApiTranslationValues(requirementSpecification.quantitySpecification?.valueTranslations ?? []);
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.amountOfMoney = TranslationValue.getTranslationIfExist(requirementSpecification.quantitySpecification?.value ?? "", result.amountOfMoneyTranslations, mainLanguage);
    result.quantitySpecificationEntityId = requirementSpecification.quantitySpecification?.entityId ?? null;
    return result;
  }
}