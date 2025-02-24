import { ApplicationModelsApiModelsApiRequirementSpecificationPerson } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { ApplicationModelsApiModelsApiSkillSpecification } from "../../../server/model/applicationModelsApiModelsApiSkillSpecification";
import { SelectOption } from "../../../shared/models/select-option";
import { ObjectCreator } from "../../../shared/tools/object-creator";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";

export declare type EffortHoursType = "perWeek" | "total"
export class RequirementPersonInput{
  effortHoursType: EffortHoursType = "perWeek";
  hours: string = "";
  selectedSkills: SelectOption[] = [];  
  numberOfPersons: string = "1";
  requirementTimeIsIdenticalToProjectTime: boolean = true
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementLocationIsIdenticalToProjectLocation: boolean = true
  requirementLocations: LocationInput[] = [new LocationInput()];

  toRequirementPersonSpecification(): ApplicationModelsApiModelsApiRequirementSpecificationPerson {
    return {
        classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Person,
        quantitySpecification: {
            value: this.numberOfPersons
        },
        skillSpecifications: this.selectedSkills.map(x => ObjectCreator.Create<ApplicationModelsApiModelsApiSkillSpecification>({
            name: x.value,
            title: {
                rawContentString: x.text
            }
        })),
        workAmountSpecification: {
            value: `${this.hours}h ${this.effortHoursType}`
        },
        timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,
        locationSpecificationsSameAsProject: this.requirementLocationIsIdenticalToProjectLocation,
        locationSpecifications: this.requirementLocationIsIdenticalToProjectLocation ? [] : this.requirementLocations.map(x => x.toLocationSpecification()).filter(x => !!x),
        timeSpecifications:  this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)        
    };
  }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationPerson) {
    const result = new RequirementPersonInput();
    result.numberOfPersons = requirementSpecification.quantitySpecification?.value ?? "";
    result.hours = requirementSpecification.workAmountSpecification?.value?.split(" ")[0] ?? "";
    result.effortHoursType = requirementSpecification.workAmountSpecification?.value?.split(" ")[1]?.toLowerCase()?.trim() === "perweek" ? "perWeek" : "total";
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementLocationIsIdenticalToProjectLocation = requirementSpecification.locationSpecificationsSameAsProject ?? true;
    result.requirementLocations = requirementSpecification.locationSpecifications?.map(x => LocationInput.fromLocationSpecification(x))?.filter(x => !!x) ?? [];
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.selectedSkills = requirementSpecification.skillSpecifications?.map(x => new SelectOption(x.name ?? "", x.title?.rawContentString ?? "")).filter(x => !!x.value) ?? [];
    return result;
  }
}