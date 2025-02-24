import { ApplicationModelsApiModelsApiRequirementSpecificationMaterial } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import { ApplicationModelsApiModelsApiRequirementSpecificationTypes } from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationTypes";
import { SelectOptionMaterial } from "../../../shared/models/select-option-material";
import { LocationInput } from "./location-input";
import { ProjectTimeInput } from "./project-time-input";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationPerson
} from "../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson";
import {SelectOption} from "../../../shared/models/select-option";

export class RequirementMaterialInput{
  selectedMaterials: SelectOptionMaterial[] = [];  
  requirementTimeIsIdenticalToProjectTime: boolean = true
  requirementTimes: ProjectTimeInput[] = [new ProjectTimeInput()];
  requirementLocationIsIdenticalToProjectLocation: boolean = true
  requirementLocations: LocationInput[] = [new LocationInput()];
    
  toRequirementMaterialSpecifications(): ApplicationModelsApiModelsApiRequirementSpecificationMaterial[] {
    return this.selectedMaterials.map(x => {
        return {
            classType: ApplicationModelsApiModelsApiRequirementSpecificationTypes.Material,
            quantitySpecification: {
                value: x.amount
            },            
            materialSpecifications: [{
                name: x.value,
                title: {
                    rawContentString: x.text
                },
                description: {
                    rawContentString: x.description
                }
            }],            
            timeSpecificationSameAsProject: this.requirementTimeIsIdenticalToProjectTime,
            locationSpecificationsSameAsProject: this.requirementLocationIsIdenticalToProjectLocation,
            locationSpecifications: this.requirementLocationIsIdenticalToProjectLocation ? [] : this.requirementLocations.map(x => x.toLocationSpecification()).filter(x => !!x),
            timeSpecifications:  this.requirementTimeIsIdenticalToProjectTime ? [] : this.requirementTimes.map(x => x.toTimeSpecification()).filter(x => !!x)            
        }
    })
  }

  static fromRequirementSpecification(requirementSpecification: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    const result = new RequirementMaterialInput();
    result.requirementTimeIsIdenticalToProjectTime = requirementSpecification.timeSpecificationSameAsProject ?? true;
    result.requirementLocationIsIdenticalToProjectLocation = requirementSpecification.locationSpecificationsSameAsProject ?? true;
    result.requirementLocations = requirementSpecification.locationSpecifications?.map(x => LocationInput.fromLocationSpecification(x))?.filter(x => !!x) ?? [];
    result.requirementTimes = requirementSpecification.timeSpecifications?.map(x => ProjectTimeInput.fromTimeSpecification(x))?.filter(x => !!x) ?? [];
    result.selectedMaterials = requirementSpecification.materialSpecifications?.map(x => new SelectOptionMaterial(x.name ?? "", x.title?.rawContentString ?? "", x.amountValue ?? "", x.description?.rawContentString ?? "")).filter(x => !!x.value) ?? [];
    return result;
  }
}