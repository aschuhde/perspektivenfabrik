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
    
}