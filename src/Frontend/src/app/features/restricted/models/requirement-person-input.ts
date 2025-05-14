import { ApplicationModelsApiModelsApiRequirementSpecificationPerson } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { ApplicationModelsApiModelsApiSkillSpecification } from "../../../server/model/applicationModelsApiModelsApiSkillSpecification";
import { SelectOption } from "../../../shared/models/select-option";
import { ObjectCreator } from "../../../shared/tools/object-creator";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";
import {getEffortHoursWithHourUnit, parseEffortHours} from "../../../shared/tools/parsing";
import {TranslationValue} from "../../../shared/models/translation-value";
import {Language} from "../../../core/types/general-types";

export declare type EffortHoursType = "perWeek" | "total"
export class RequirementPersonInput{
    entityId: string | null = null;
    quantitySpecificationEntityId: string | null = null;
    workAmountEntityId: string | null = null;
  effortHoursType: EffortHoursType = "perWeek";
  hours: string = "";
  selectedSkills: SelectOption[] = [];  
  numberOfPersons: string = "1";
  numberOfPersonsTranslations: TranslationValue[] = [];
  requirementTimeIsIdenticalToProjectTime: boolean = true
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementLocationIsIdenticalToProjectLocation: boolean = true
  requirementLocations: LocationInput[] = [new LocationInput()];

  getHoursWithUnit(){
      return getEffortHoursWithHourUnit(this.hours);
  }
  
  toRequirementPersonSpecification(mainLanguage: Language): ApplicationModelsApiModelsApiRequirementSpecificationPerson {
    return {
        classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person,
        entityId: this.entityId ?? undefined,
        quantitySpecification: {
            value: TranslationValue.getTranslationIfExist(this.numberOfPersons, this.numberOfPersonsTranslations, mainLanguage),
            entityId: this.quantitySpecificationEntityId ?? undefined,
            valueTranslations: TranslationValue.toApiTranslationValues(this.numberOfPersonsTranslations)
        },
        skillSpecifications: this.selectedSkills.map(x => ObjectCreator.Create<ApplicationModelsApiModelsApiSkillSpecification>({
            name: TranslationValue.getTranslationIfExist(x.value,x.valueTranslations, mainLanguage),
            nameTranslations: TranslationValue.toApiTranslationValues(x.valueTranslations),
            entityId: x.entityId ?? undefined,
            title: {
                rawContentString: TranslationValue.getTranslationIfExist(x.text,x.textTranslations, mainLanguage),
                contentTranslations: TranslationValue.toApiTranslationValues(x.textTranslations)
            }
        })),
        workAmountSpecification: {
            value: `${this.getHoursWithUnit()} ${this.effortHoursType}`,
            entityId: this.workAmountEntityId ?? undefined
        },
        timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,
        locationSpecificationsSameAsProject: this.requirementLocationIsIdenticalToProjectLocation,
        locationSpecifications: this.requirementLocationIsIdenticalToProjectLocation ? [] : this.requirementLocations.map(x => x.toLocationSpecification(mainLanguage)).filter(x => !!x),
        timeSpecifications:  this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)        
    };
  }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationPerson, mainLanguage: Language) {
      const effortHours = parseEffortHours(requirementSpecification.workAmountSpecification?.value);
    const result = new RequirementPersonInput();
    result.entityId = requirementSpecification.entityId ?? null;
    result.quantitySpecificationEntityId = requirementSpecification.quantitySpecification?.entityId ?? null;
    result.workAmountEntityId = requirementSpecification.workAmountSpecification?.entityId ?? null;
    
    result.numberOfPersonsTranslations = TranslationValue.arrayFromApiTranslationValues(requirementSpecification.quantitySpecification?.valueTranslations ?? []);
    result.numberOfPersons = TranslationValue.getTranslationIfExist(requirementSpecification.quantitySpecification?.value ?? "", result.numberOfPersonsTranslations, mainLanguage);
    result.hours = effortHours?.effortHours ?? "";
    result.effortHoursType = effortHours?.effortHoursType ?? "perWeek";
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementLocationIsIdenticalToProjectLocation = requirementSpecification.locationSpecificationsSameAsProject ?? true;
    result.requirementLocations = requirementSpecification.locationSpecifications?.map(x => LocationInput.fromLocationSpecification(x, mainLanguage))?.filter(x => !!x) ?? [];
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.selectedSkills = requirementSpecification.skillSpecifications?.map(x => {
        const nameTranslations = TranslationValue.arrayFromApiTranslationValues(x.nameTranslations ?? []);
        const titleTranslations = TranslationValue.arrayFromApiTranslationValues(x.title?.contentTranslations ?? []);
        return new SelectOption(TranslationValue.getTranslationIfExist(x.name ?? "", nameTranslations, mainLanguage), TranslationValue.getTranslationIfExist(x.title?.rawContentString ?? "", titleTranslations, mainLanguage), x.entityId ?? null
            , nameTranslations
            , titleTranslations);
    }).filter(x => !!x.value) ?? [];
    return result;
  }
}