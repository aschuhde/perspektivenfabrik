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

@Component({
  selector: 'app-project-detail',
    imports: [ImageGalleryComponent, MatIconModule],
  templateUrl: './project-detail.component.html',
  styleUrl: './project-detail.component.scss'
})
export class ProjectDetailComponent {    
    apiProject = model.required<ApplicationModelsApiModelsApiProject | null>();
    localeDataProvider = inject(LocaleDataProvider)
    apiProjectModel = new ApiProjectModel()

  get project(){
    return this.apiProjectModel.project;
  }
  get shortDescription(){
    return this.apiProjectModel.shortDescription;
  }
  get longDescription(){
    return this.apiProjectModel.longDescription;
  }
  get projectTitle(){
    return this.apiProjectModel.projectTitle;
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
    return this.apiProjectModel.contactPersonalName;
  }
  get contactOrganisationName(){
    return this.apiProjectModel.contactOrganisationName;
  }
  get contactPhone(){
    return this.apiProjectModel.contactPhone;
  }
  get contactMailAddress(){
    return this.apiProjectModel.contactMailAddress;
  }
    get contactWebsite(){
      return this.apiProjectModel.contactWebsite;
    }

    ngOnChanges(changes: SimpleChanges) {
        if(changes["apiProject"]?.currentValue){
          this.apiProjectModel.loadFromApiProject(changes["apiProject"]?.currentValue, this.localeDataProvider);           
        }
    }
    getLocationSpecificationShortName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification){
        return this.apiProjectModel.getLocationSpecificationShortName(locationSpecification, this.localeDataProvider);
    }

    getLocationSpecificationIconName(locationSpecification: ApplicationModelsApiModelsApiLocationSpecification): string {
      return this.apiProjectModel.getLocationSpecificationIconName(locationSpecification);
    }

    getTimeSpecificationShortName(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification): string{
      return this.apiProjectModel.getTimeSpecificationShortName(timeSpecification, this.localeDataProvider);
    }
    getTimeSpecificationIcon(timeSpecification: ApplicationModelsApiModelsApiTimeSpecification){
      return this.apiProjectModel.getTimeSpecificationIcon(timeSpecification);
    }
    getTagShortName(tag: ApplicationModelsApiModelsApiProjectTag){
      return this.apiProjectModel.getTagShortName(tag);
    }

    getRequirementSpecificationPersonShortName(requirementSpecificationPerson: ApplicationModelsApiModelsApiRequirementSpecificationPerson | undefined){
      return this.apiProjectModel.getRequirementSpecificationPersonShortName(requirementSpecificationPerson);
    }

    getRequirementSpecificationMaterialShortName(requirementSpecificationMaterial: ApplicationModelsApiModelsApiRequirementSpecification){
      return this.apiProjectModel.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterial);
    }

    getRequirementSpecificationMoneyShortName(requirementSpecificationMoney: ApplicationModelsApiModelsApiRequirementSpecification){
      return this.apiProjectModel.getRequirementSpecificationMoneyShortName(requirementSpecificationMoney, this.localeDataProvider);
    }
}
