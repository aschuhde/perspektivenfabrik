import {Component, inject, input} from '@angular/core';
import {ApiService} from "../../../../server/api/api.service";
import { ApiProjectModel } from '../../models/api-project-model';
import {LocaleDataProvider} from "../../../../core/services/locale-data.service";
import {
  ApplicationModelsApiModelsApiLocationSpecification
} from "../../../../server/model/applicationModelsApiModelsApiLocationSpecification";
import { joinWithConjunction } from '../../../../shared/tools/string-join-tools';
import { MoreIconComponent } from '../../../../shared/components/more-icon/more-icon.component';
import {MatIcon} from "@angular/material/icon";
import {
  ApplicationModelsApiModelsApiTimeSpecification
} from "../../../../server/model/applicationModelsApiModelsApiTimeSpecification";
import {
  ApplicationModelsApiModelsApiProjectTag
} from "../../../../server/model/applicationModelsApiModelsApiProjectTag";
@Component({
  selector: 'app-project-list',
  imports: [MoreIconComponent, MatIcon],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.scss'
})
export class ProjectListComponent {
  apiService = inject(ApiService)
  projects: ApiProjectModel[] = []
  localeDataProvider = inject(LocaleDataProvider)
  type = input<"home" | "user-area">("home")
  loadProjects(){
    if(this.type() === "user-area"){
      const projectsResponse = this.apiService.webApiEndpointsGetUsersProjects();

      projectsResponse.subscribe(x => {
        if(x.projects){
          this.projects = x.projects?.map(x => {
            return (new ApiProjectModel()).loadFromApiProject(x, this.localeDataProvider);
          }) ?? [];
        }
      });
      return;
    }
    const projectsResponse = this.apiService.webApiEndpointsGetProjects();

    projectsResponse.subscribe(x => {
      if(x.projects){
        this.projects = x.projects?.map(x => {
          return (new ApiProjectModel()).loadFromApiProject(x, this.localeDataProvider);
        }) ?? [];
      }
    });
  }

  ngOnInit(){
    this.loadProjects();
  }

  getLocationSpecificationText(project: ApiProjectModel) {
    const locationSpecifications = project.locationSpecifications;
    if((locationSpecifications?.length ?? 0) === 0){
      return "";
    }
    if(locationSpecifications?.length === 1){
      return project.getLocationSpecificationShortName(locationSpecifications[0], this.localeDataProvider);
    }
    if(locationSpecifications?.length === 2){
      return joinWithConjunction(locationSpecifications.map(x => project.getLocationSpecificationShortName(x, this.localeDataProvider) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getLocationSpecificationShortName(locationSpecifications[0], this.localeDataProvider)}, ${project.getLocationSpecificationShortName(locationSpecifications[1], this.localeDataProvider)}...`;
  }

  needLocationSpecificationPlusIcons(locationSpecifications: ApplicationModelsApiModelsApiLocationSpecification[]) {
    return locationSpecifications.length > 2;
  }

  getLocationSpecificationPlusIconCount(locationSpecifications: ApplicationModelsApiModelsApiLocationSpecification[]) {
    return locationSpecifications.length - 2;
  }

  getLocationSpecificationTooltipContent(project: ApiProjectModel) {
    return joinWithConjunction(project.locationSpecifications.slice(2).map(x => project.getLocationSpecificationShortName(x, this.localeDataProvider) ?? ""), this.localeDataProvider.locale)
  }


  getTimeSpecificationText(project: ApiProjectModel) {
    const timeSpecifications = project.timeSpecifications;
    if((timeSpecifications?.length ?? 0) === 0){
      return "";
    }
    if(timeSpecifications?.length === 1){
      return project.getTimeSpecificationShortName(timeSpecifications[0], this.localeDataProvider);
    }
    if(timeSpecifications?.length === 2){
      return joinWithConjunction(timeSpecifications.map(x => project.getTimeSpecificationShortName(x, this.localeDataProvider) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getTimeSpecificationShortName(timeSpecifications[0], this.localeDataProvider)}, ${project.getTimeSpecificationShortName(timeSpecifications[1], this.localeDataProvider)}...`;
  }

  needTimeSpecificationPlusIcons(timeSpecifications: ApplicationModelsApiModelsApiTimeSpecification[]) {
    return timeSpecifications.length > 2;
  }

  getTimeSpecificationPlusIconCount(timeSpecifications: ApplicationModelsApiModelsApiTimeSpecification[]) {
    return timeSpecifications.length - 2;
  }

  getTimeSpecificationTooltipContent(project: ApiProjectModel) {
    return joinWithConjunction(project.timeSpecifications.slice(2).map(x => project.getTimeSpecificationShortName(x, this.localeDataProvider) ?? ""), this.localeDataProvider.locale)
  }

  getTagText(project: ApiProjectModel) {
    const tags = project.tags;
    if((tags?.length ?? 0) === 0){
      return "";
    }
    if(tags?.length === 1){
      return project.getTagShortName(tags[0]);
    }
    if(tags?.length === 2){
      return joinWithConjunction(tags.map(x => project.getTagShortName(x) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getTagShortName(tags[0])}, ${project.getTagShortName(tags[1])}...`;
  }

  needTagPlusIcons(tags: ApplicationModelsApiModelsApiProjectTag[]) {
    return tags.length > 2;
  }

  getTagPlusIconCount(tags: ApplicationModelsApiModelsApiProjectTag[]) {
    return tags.length - 2;
  }

  getTagTooltipContent(project: ApiProjectModel) {
    return joinWithConjunction(project.tags.slice(2).map(x => project.getTagShortName(x) ?? ""), this.localeDataProvider.locale)
  }

  getRequirementPersonText(project: ApiProjectModel) {
    const requirementSpecificationPersonsFlat = project.requirementSpecificationPersonsFlat;
    if((requirementSpecificationPersonsFlat?.length ?? 0) === 0){
      return "";
    }
    if(requirementSpecificationPersonsFlat?.length === 1){
      return project.getRequirementSpecificationPersonShortName(requirementSpecificationPersonsFlat[0]);
    }
    if(requirementSpecificationPersonsFlat?.length === 2){
      return joinWithConjunction(requirementSpecificationPersonsFlat.map(x => project.getRequirementSpecificationPersonShortName(x) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getRequirementSpecificationPersonShortName(requirementSpecificationPersonsFlat[0])}, ${project.getRequirementSpecificationPersonShortName(requirementSpecificationPersonsFlat[1])}...`;
  }

  getRequirementMaterialText(project: ApiProjectModel) {
    const requirementSpecificationMaterialsFlat = project.requirementSpecificationMaterialsFlat;
    if((requirementSpecificationMaterialsFlat?.length ?? 0) === 0){
      return "";
    }
    if(requirementSpecificationMaterialsFlat?.length === 1){
      return project.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterialsFlat[0]);
    }
    if(requirementSpecificationMaterialsFlat?.length === 2){
      return joinWithConjunction(requirementSpecificationMaterialsFlat.map(x => project.getRequirementSpecificationMaterialShortName(x) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterialsFlat[0])}, ${project.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterialsFlat[1])}...`;
  }
  
  getRequirementMoneyText(project: ApiProjectModel) {
    const requirementSpecificationMoneySummed = project.requirementSpecificationMoneySummed;
    if(!requirementSpecificationMoneySummed){
      return "";
    }
    return project.getRequirementSpecificationMoneyShortName(requirementSpecificationMoneySummed, this.localeDataProvider);
  }
}
