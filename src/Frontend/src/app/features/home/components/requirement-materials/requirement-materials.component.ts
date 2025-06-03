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
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import { of } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import {Language} from "../../../../core/types/general-types";

@Component({
  selector: 'app-requirement-materials',
  imports: [MatIconModule, TranslateModule, AsyncPipe],
  templateUrl: './requirement-materials.component.html',
  styleUrl: './requirement-materials.component.scss'
})
export class RequirementMaterialsComponent {
  requirements = input<ApplicationModelsApiModelsApiRequirementSpecificationMaterial[]>([])
  requirementsMoney = input<ApplicationModelsApiModelsApiRequirementSpecificationMoney[]>([])
  localDataProvider = inject(LocaleDataProvider)
  translateService = inject(TranslateService)
  
  materialSpecificationHtml(materialSpecification: ApplicationModelsApiModelsApiMaterialSpecification) {
    if(!materialSpecification) return "-";
    let titleTranslation = materialSpecification.title?.contentTranslations?.find(x => x.languageCode == this.translateService.currentLang as Language);
    let title = materialSpecification.title?.rawContentString;
    if(titleTranslation?.value){
      title = titleTranslation.value;
    }
    if(!title){
      return "-";
    }
    let suffix = "";
    const amountValueTranslation = materialSpecification.amountValueTranslations?.find(x => x.languageCode == this.translateService.currentLang as Language);
    if(amountValueTranslation && amountValueTranslation.value){
      suffix = `${amountValueTranslation.value}`
    }else if(materialSpecification.amountValue){
      suffix = `${materialSpecification.amountValue}`
    }
    
    const descriptionTranslation = materialSpecification.description?.contentTranslations?.find(x => x.languageCode == this.translateService.currentLang as Language);
    let description = materialSpecification.description?.rawContentString;
    if(descriptionTranslation?.value){
      description = descriptionTranslation.value;
    }
    if(description && suffix){
      suffix += ` - <i>${description}</i>`;
    }else if(description){
      suffix = `<i>${description}</i>`;
    }
    if(suffix){
      suffix = ` (${suffix})`;
    }
    return `<strong>${title}</strong>${suffix}`;
  }
  
  materialHtml(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    return stringEmptyPropagate(joinWithConjunction(requirement?.materialSpecifications?.map(x => this.materialSpecificationHtml(x)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-");
  }
  moneyText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMoney) {
    return stringEmptyPropagate(formatMoney(requirement?.quantitySpecification?.value, this.localDataProvider.locale, "euro"), "-");
  }

  periodText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMaterial | ApplicationModelsApiModelsApiRequirementSpecificationMoney) {
    if(requirement.timeSpecificationSameAsProject){
      return this.translateService.stream("general.inTheSameTimeOfTheProject")
    }
    return of(stringEmptyPropagate(joinWithConjunction(requirement?.timeSpecifications?.map(x => ApiProjectModel.getTimeSpecificationShortName(x, this.localDataProvider)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-"));
  }
  locationText(requirement: ApplicationModelsApiModelsApiRequirementSpecificationMaterial) {
    if(requirement.locationSpecificationsSameAsProject){
      return this.translateService.stream("general.atTheSameLocationOfTheProject")
    }
    return of(stringEmptyPropagate(joinWithConjunction(requirement?.locationSpecifications?.map(x => ApiProjectModel.getLocationSpecificationShortName(x, this.localDataProvider, this.translateService)).filter(x => !!x).map(x => x!), this.localDataProvider.locale), "-"));
  }
}
