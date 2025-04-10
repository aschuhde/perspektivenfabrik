import {Component, inject, input} from '@angular/core';
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";
import {stringEmptyPropagate} from "../../../../shared/tools/null-tools";
import {joinWithConjunction} from "../../../../shared/tools/string-join-tools";
import {ApiProjectModel} from "../../models/api-project-model";
import {
  ApplicationModelsApiModelsApiRequirementSpecificationMaterial
} from "../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMaterial";
import {
  ApplicationModelsApiModelsApiMaterialSpecification
} from "../../../../server/model/applicationModelsApiModelsApiMaterialSpecification";
import { ApplicationModelsApiModelsApiRequirementSpecificationMoney } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationMoney';
import {formatMoney} from "../../../../shared/tools/formatting";
import {MatIconModule} from "@angular/material/icon";

@Component({
  selector: 'app-requirement-materials',
  imports: [MatIconModule],
  templateUrl: './requirement-materials.component.html',
  styleUrl: './requirement-materials.component.scss'
})
export class RequirementMaterialsComponent {
  requirements = input<ApplicationModelsApiModelsApiRequirementSpecificationMaterial[]>([])
  requirementsMoney = input<ApplicationModelsApiModelsApiRequirementSpecificationMoney[]>([])
  localDataProvider = inject(LocaleDataProvider)
  
  materialSpecificationText(materialSpecification: ApplicationModelsApiModelsApiMaterialSpecification) {
    if(!materialSpecification?.title?.rawContentString) return "-";
    let suffix = "";
    if(materialSpecification.amountValue){
      suffix = ` (${materialSpecification.amountValue})`
    }
    return materialSpecification?.title?.rawContentString + suffix;
  }
  
  materialText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    return stringEmptyPropagate(joinWithConjunction(requirement?.materialSpecifications?.map(x => this.materialSpecificationText(x)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
  }
  moneyText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMoney) {
    return stringEmptyPropagate(formatMoney(requirement?.quantitySpecification?.value, this.localDataProvider.locale, "euro"), "-");
  }

  periodText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMaterial | ApplicationModelsApiModelsApiRequirementSpecificationMoney) {
    if(requirement.timeSpecificationSameAsProject){
      return "Im gleichen Zeitraum des Projekts"
    }
    return stringEmptyPropagate(joinWithConjunction(requirement?.timeSpecifications?.map(x => ApiProjectModel.getTimeSpecificationShortName(x, this.localDataProvider)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
  }
  locationText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    if(requirement.locationSpecificationsSameAsProject){
      return "Am gleichen Ort wie das Projekt"
    }
    return stringEmptyPropagate(joinWithConjunction(requirement?.locationSpecifications?.map(x => ApiProjectModel.getLocationSpecificationShortName(x, this.localDataProvider)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
  }
}
