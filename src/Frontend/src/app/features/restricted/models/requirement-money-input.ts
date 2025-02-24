import { ApplicationModelsApiModelsApiRequirementSpecificationMoney } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { ProjectTimeInput } from "./project-time-input";
import {LocationInput} from "./location-input";
import {SelectOptionMaterial} from "../../../shared/models/select-option-material";

export class RequirementMoneyInput{
    amountOfMoney: string = "";  
    requirementTimeIsIdenticalToProjectTime: boolean = true;
    requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
      
    toRequirementMoneySpecification(): ApplicationModelsApiModelsApiRequirementSpecificationMoney {
      return {
        classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Money,
        timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,                      
        quantitySpecification: {
            value: this.amountOfMoney
        },     
        timeSpecifications: this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)
      };
    }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationMoney) {
    const result = new RequirementMoneyInput();
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.amountOfMoney = requirementSpecification.quantitySpecification?.value ?? "";
    return result;
  }
}