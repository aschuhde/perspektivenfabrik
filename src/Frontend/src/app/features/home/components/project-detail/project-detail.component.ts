import {Component, inject, model, SimpleChanges} from '@angular/core';
import { ApplicationModelsApiModelsApiProject } from '../../../../server/model/applicationModelsApiModelsApiProject';
import { ApplicationModelsApiModelsApiLocationSpecification } from '../../../../server/model/applicationModelsApiModelsApiLocationSpecification';
import { ApplicationModelsApiModelsApiTimeSpecification } from '../../../../server/model/applicationModelsApiModelsApiTimeSpecification';
import { ApplicationModelsApiModelsApiProjectTag } from '../../../../server/model/applicationModelsApiModelsApiProjectTag';
import { ApplicationModelsApiModelsApiRequirementSpecificationPerson } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecificationPerson';
import { ApplicationModelsApiModelsApiRequirementSpecification } from '../../../../server/model/applicationModelsApiModelsApiRequirementSpecification';
import { ImageGalleryComponent } from '../../../../shared/components/image-gallery/image-gallery.component';
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";
import {MatIconModule} from "@angular/material/icon";
import { ApiProjectModel } from '../../models/api-project-model';
import {
  ApplicationModelsApiModelsApiLocationSpecificationTypes
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationTypes";
import {MatDialog} from "@angular/material/dialog";
import {MapDialogComponent} from "../../../../shared/dialogs/map-dialog/map-dialog.component";
import {
  ApplicationModelsApiModelsApiLocationSpecificationCoordinates
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationCoordinates";
import {formatCoordinates} from "../../../../shared/tools/formatting";
import {
  ApplicationModelsApiModelsApiLocationSpecificationRegion
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationRegion";
import {
  ApplicationModelsApiModelsApiLocationSpecificationAddress
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationAddress";
import {
  ApplicationModelsApiModelsApiLocationSpecificationName
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecificationName";
import {
  RequirementMaterialsDialogComponent
} from "../../dialogs/requirement-materials-dialog/requirement-materials-dialog.component";
import { RequirementPersonsDialogComponent } from '../../dialogs/requirement-persons-dialog/requirement-persons-dialog.component';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {TranslationValue} from "../../../../shared/models/translation-value";
import {BASE_PATH} from "../../../../server/variables";
import {Language} from "../../../../core/types/general-types";
import {InstaIconComponent} from "../../../../shared/components/insta-icon/insta-icon.component";
import {GithubIconComponent} from "../../../../shared/components/github-icon/github-icon.component";
import {FacebookIconComponent} from "../../../../shared/components/facebook-icon/facebook-icon.component";
import {trimChar} from "../../../../shared/tools/string-tools";
import {stringEmptyPropagate} from "../../../../shared/tools/null-tools";
import {
  ApplicationModelsApiModelsApiContactSpecificationWebsite
} from "../../../../server/model/applicationModelsApiModelsApiContactSpecificationWebsite";
import { ReportProjectDialogComponent } from '../../dialogs/report-project-dialog/report-project-dialog.component';
import {ActivatedRoute} from "@angular/router";
import {MessageDialogComponent} from "../../../../shared/dialogs/message-dialog/message-dialog.component";

@Component({
  selector: 'app-project-detail',
  imports: [ImageGalleryComponent, MatIconModule, TranslateModule, InstaIconComponent, GithubIconComponent, FacebookIconComponent],
  templateUrl: './project-detail.component.html',
  styleUrl: './project-detail.component.scss'
})
export class ProjectDetailComponent {
    
      
    apiProject = model.required<ApplicationModelsApiModelsApiProject | null>();
    localeDataProvider = inject(LocaleDataProvider)
    apiProjectModel = new ApiProjectModel()
  readonly dialog = inject(MatDialog);
    translateService = inject(TranslateService);
  apiBasePath = inject(BASE_PATH)
  route = inject(ActivatedRoute)

  get project(){
    return this.apiProjectModel.project;
  }
  get shortDescription(){
    return stringEmptyPropagate(this.apiProjectModel.getShortDescriptionContent(this.translateService.currentLang as Language), this.apiProjectModel.getLongDescriptionContent(this.translateService.currentLang as Language));
  }
  get longDescription(){
    return stringEmptyPropagate(this.apiProjectModel.getLongDescriptionContent(this.translateService.currentLang as Language), this.apiProjectModel.getShortDescriptionContent(this.translateService.currentLang as Language));
  }
  get projectTitle(){
    return this.apiProjectModel.getProjectTitleContent(this.translateService.currentLang as Language);
  }
  get projectImages(){
    return this.apiProjectModel.projectImages;
  }
  get locationSpecifications(){
    return this.apiProjectModel.locationSpecifications;
  }
  get timeSpecifications(){
    return this.apiProjectModel.timeSpecifications;
  }
  get tags(){
    return this.apiProjectModel.tags;
  }
  get requirementSpecificationPersons(){
    return this.apiProjectModel.requirementSpecificationPersons;
  }
  get requirementSpecificationPersonsFlat(){
    return this.apiProjectModel.requirementSpecificationPersonsFlat;
  }
  get requirementSpecificationMaterials(){
    return this.apiProjectModel.requirementSpecificationMaterials;
  }
  get requirementSpecificationMaterialsFlat(){
    return this.apiProjectModel.requirementSpecificationMaterialsFlat;
  }
  get requirementSpecificationMoney(){
    return this.apiProjectModel.requirementSpecificationMoney;
  }
  get requirementSpecificationMoneySummed(){
    return this.apiProjectModel.requirementSpecificationMoneySummed;
  }
  get contactPersonalName(){
    return this.apiProjectModel.getContactPersonalNameContent(this.translateService.currentLang as Language);
  }
  get contactOrganisationName(){
    return this.apiProjectModel.getContactOrganisationNameContent(this.translateService.currentLang as Language);
  }
  get contactPhone(){
    return this.apiProjectModel.getContactPhoneNumberContent(this.translateService.currentLang as Language);
  }
  get contactMailAddress(){
    return this.apiProjectModel.getContactMailAddressContent(this.translateService.currentLang as Language);
  }
    get contactWebsites(){
      return this.apiProjectModel.contactWebsites;
    }

    ngOnChanges(changes: SimpleChanges) {
        if(changes["apiProject"]?.currentValue){
          this.apiProjectModel.loadFromApiProject(changes["apiProject"]?.currentValue, this.localeDataProvider, this.apiBasePath);
          if(this.route.snapshot.queryParams["open-report-dialog"] === "true"){
            this.startReportProject();
          }
        }
    }
    getLocationSpecificationShortName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
        return ApiProjectModel.getLocationSpecificationShortName(locationSpecification, this.localeDataProvider, this.translateService);
    }

    getLocationSpecificationIconName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification): string {
      return this.apiProjectModel.getLocationSpecificationIconName(locationSpecification);
    }

    getTimeSpecificationShortName(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification): string{
      return ApiProjectModel.getTimeSpecificationShortName(timeSpecification, this.localeDataProvider);
    }
    getTimeSpecificationIcon(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification){
      return this.apiProjectModel.getTimeSpecificationIcon(timeSpecification);
    }
    getTagShortName(tag: ApplicationModelsApiModelsApiProjectTag){
      return this.apiProjectModel.getTagShortName(tag, this.translateService.currentLang as Language);
    }

    getRequirementSpecificationPersonShortName(requirementSpecificationPerson: ApplicationModelsApiModelsApiRequirementSpecificationPerson | undefined){
      return this.apiProjectModel.getRequirementSpecificationPersonShortName(requirementSpecificationPerson, this.translateService.currentLang as Language);
    }

    getRequirementSpecificationMaterialShortName(requirementSpecificationMaterial: ApplicationModelsApiModelsApiRequirementSpecification){
      return this.apiProjectModel.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterial, this.translateService.currentLang as Language);
    }

    getRequirementSpecificationMoneyShortName(requirementSpecificationMoney: ApplicationModelsApiModelsApiRequirementSpecification){
      return this.apiProjectModel.getRequirementSpecificationMoneyShortName(requirementSpecificationMoney, this.localeDataProvider);
    }
    getMapLookupMode(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
      if(locationSpecification.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates){
        return "latLon";
      }
      return "address";
    }
    getLocationSpecificationString(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
      if(locationSpecification.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Coordinates){
        return formatCoordinates((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationCoordinates).coordinates, this.localeDataProvider.locale);
      }
      if(locationSpecification.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Region){
        return TranslationValue.getTranslationIfExist((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationRegion).region?.addressText ?? "",
            TranslationValue.arrayFromApiTranslationValues((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationRegion).region?.addressTextTranslations ?? []), this.translateService.currentLang as Language);
      }
      if(locationSpecification.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Address){
        return TranslationValue.getTranslationIfExist((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationAddress).postalAddress?.addressText ?? "",
            TranslationValue.arrayFromApiTranslationValues((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationAddress).postalAddress?.addressTextTranslations ?? []), this.translateService.currentLang as Language);
      }
      if(locationSpecification.classType === ApplicationModelsApiModelsApiLocationSpecificationTypes.Name){
        return TranslationValue.getTranslationIfExist((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationName).postalAddress?.addressText ?? "",
            TranslationValue.arrayFromApiTranslationValues((locationSpecification as ApplicationModelsApiModelsApiLocationSpecificationName).postalAddress?.addressTextTranslations ?? []), this.translateService.currentLang as Language);
      }
      return "";
    }
    locationClicked(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
      const startPoint = this.getLocationSpecificationString(locationSpecification);
      if(!startPoint) return;
      this.dialog.open(MapDialogComponent, {
        data: {
          type: "display",
          lookupMode: this.getMapLookupMode(locationSpecification),
          startPoint: startPoint
        }
      });
    }
    isLocationClickable(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification): boolean{
      return locationSpecification.classType !== ApplicationModelsApiModelsApiLocationSpecificationTypes.Remote
        && locationSpecification.classType !== ApplicationModelsApiModelsApiLocationSpecificationTypes.Base  
        && locationSpecification.classType !== ApplicationModelsApiModelsApiLocationSpecificationTypes.EntireProvince;  
    }
    requirementSpecificationPersonClicked(){
      this.showRequirementPersonsDialog();
    }
    requirementSpecificationMaterialClicked(){
      this.showRequirementMaterialsDialog();
    }
    requirementSpecificationMoneyClicked(){
      this.showRequirementMaterialsDialog();
    }
    
    showRequirementMaterialsDialog(){
      if(this.requirementSpecificationMaterials.length === 0 && this.requirementSpecificationMoney.length === 0){
        return
      }
      this.dialog.open(RequirementMaterialsDialogComponent, {
        data: {
          requirementMaterials: this.requirementSpecificationMaterials,
          requirementsMoney: this.requirementSpecificationMoney,
        }
      });
    }
    showRequirementPersonsDialog(){
      if(this.requirementSpecificationPersons.length === 0){
        return
      }
      this.dialog.open(RequirementPersonsDialogComponent, {
        data: {
          requirementPersons: this.requirementSpecificationPersons,
        }
      });
    }

  isInstagram(url: string) {
    try {
      return new URL(url).hostname.toLowerCase().includes('instagram.com');
    } catch {
      return false;
    }
  }

  getInstaName(url: string){
    try {
      return "@" + trimChar(new URL(url).pathname, "/");
    } catch {
      return url;
    }
  }

  isGithub(url: string) {
    try {
      return new URL(url).hostname.toLowerCase().includes('github.com');
    } catch {
      return false;
    }
  }

  getGithubName(url: string){
    try {
      return trimChar(new URL(url).pathname, "/");
    } catch {
      return url;
    }
  }

  isFacebook(url: string) {
    try {
      return new URL(url).hostname.toLowerCase().includes('facebook.com');
    } catch {
      return false;
    }
  }
  
  getFacebookName(url: string){
    try {
      return trimChar(new URL(url).pathname, "/");
    } catch {
      return url;
    }
  }
  
  getWebsiteUrl(website: ApplicationModelsApiModelsApiContactSpecificationWebsite){
    const language = this.translateService.currentLang as Language;
    if(!website) return "";

    const urlTranslation = website.website?.urlTranslations?.find(x => x.languageCode == language);
    if(urlTranslation && urlTranslation.value){
      return urlTranslation.value;
    }
    return website.website?.rawUrl ?? "";
  }

  startReportProject() {
    this.dialog.open(ReportProjectDialogComponent, {
      data: {
        projectEntityId: this.project?.entityId,
        projectTitle: this.projectTitle,
        onSubmitted: () => {
          this.dialog.open(MessageDialogComponent, {
            data: {
              title: this.translateService.instant("report-project.submitted-title"),
              message: this.translateService.instant("report-project.submitted-message"),
              isHtmlMessage: false,
              buttonText: this.translateService.instant("general.close")
            }
          });
        }
      }
    });
  }
}
