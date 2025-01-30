import { ApplicationModelsApiModelsApiRequirementSpecificationMoney } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { ProjectTimeInput } from "./project-time-input";

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
    
}