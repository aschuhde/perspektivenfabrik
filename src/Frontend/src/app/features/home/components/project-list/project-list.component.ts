import {Component, CUSTOM_ELEMENTS_SCHEMA, inject, input} from '@angular/core';
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
import { HomeRouteNames } from '../../home-route-names';
import { RestrictedRouteNames } from '../../../restricted/restricted-route-names';
import { TranslateModule, TranslateService } from '@ngx-translate/core';
import {isServer} from "../../../../shared/tools/server-tools";
import {BASE_PATH} from "../../../../server/variables";
import {Language} from "../../../../core/types/general-types";
import {ActivatedRoute} from "@angular/router";
import {MatDialog} from "@angular/material/dialog";
import { catchError } from 'rxjs/operators';
import {
  RejectProjectDialogComponent
} from "../../../restricted/dialogs/reject-project-dialog/reject-project-dialog.component";
import {ObjectCreator} from "../../../../shared/tools/object-creator";
import {
  ApplicationPutProjectApprovalStatusPutProjectApprovalStatusPutProjectApprovalStatusRequest
} from "../../../../server/model/applicationPutProjectApprovalStatusPutProjectApprovalStatusPutProjectApprovalStatusRequest";

@Component({
  selector: 'app-project-list',
  imports: [MoreIconComponent, MatIcon, TranslateModule],
  templateUrl: './project-list.component.html',
  styleUrl: './project-list.component.scss',
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class ProjectListComponent {
  
  apiService = inject(ApiService)
  projects: ApiProjectModel[] = []
  localeDataProvider = inject(LocaleDataProvider)
  type = input<"home" | "user-area" | "pending-approvals">("home")
  translateService = inject(TranslateService)
  apiBasePath = inject(BASE_PATH)
  activatedRoute = inject(ActivatedRoute)
  dialog = inject(MatDialog)
  
  get currentLang() {
    return this.translateService.currentLang as Language;
  }
  loadProjects(){
    if(isServer()) return;
    
    if(this.type() === "user-area"){
      const projectsResponse = this.apiService.webApiEndpointsGetUsersProjects();

      projectsResponse.subscribe(x => {
        if(x.projects){
          this.projects = x.projects?.map(y => {
            return (new ApiProjectModel()).loadFromApiProject(y, this.localeDataProvider, this.apiBasePath);
          }) ?? [];
        }
      });
      return;
    }
    if(this.type() === "pending-approvals"){
      const projectsResponse = this.apiService.webApiEndpointsGetPendingApprovalProjects(this.activatedRoute.snapshot.paramMap.get("with-rejected-and-approved")?.trim() === "true");

      projectsResponse.subscribe(x => {
        if((x as any).projects){
          this.projects = (x as any).projects?.map((y: any) => {
            return (new ApiProjectModel()).loadFromApiProject(y, this.localeDataProvider, this.apiBasePath);
          }) ?? [];
        }
      });
      return;
    }
    const projectsResponse = this.apiService.webApiEndpointsGetProjects();

    projectsResponse.subscribe(x => {
      if(x.projects){
        this.projects = x.projects?.map(y => {
          return (new ApiProjectModel()).loadFromApiProject(y, this.localeDataProvider, this.apiBasePath);
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
      return ApiProjectModel.getLocationSpecificationShortName(locationSpecifications[0], this.localeDataProvider, this.translateService);
    }
    if(locationSpecifications?.length === 2){
      return joinWithConjunction(locationSpecifications.map(x => ApiProjectModel.getLocationSpecificationShortName(x, this.localeDataProvider, this.translateService) ?? ""), this.localeDataProvider.locale);
    }
    return `${ApiProjectModel.getLocationSpecificationShortName(locationSpecifications[0], this.localeDataProvider, this.translateService)}, ${ApiProjectModel.getLocationSpecificationShortName(locationSpecifications[1], this.localeDataProvider, this.translateService)}...`;
  }

  needLocationSpecificationPlusIcons(locationSpecifications: ApplicationModelsApiModelsApiLocationSpecification[]) {
    return locationSpecifications.length > 2;
  }

  getLocationSpecificationPlusIconCount(locationSpecifications: ApplicationModelsApiModelsApiLocationSpecification[]) {
    return locationSpecifications.length - 2;
  }

  getLocationSpecificationTooltipContent(project: ApiProjectModel) {
    return joinWithConjunction(project.locationSpecifications.slice(2).map(x => ApiProjectModel.getLocationSpecificationShortName(x, this.localeDataProvider, this.translateService) ?? ""), this.localeDataProvider.locale)
  }


  getTimeSpecificationText(project: ApiProjectModel) {
    const timeSpecifications = project.timeSpecifications;
    if((timeSpecifications?.length ?? 0) === 0){
      return "";
    }
    if(timeSpecifications?.length === 1){
      return ApiProjectModel.getTimeSpecificationShortName(timeSpecifications[0], this.localeDataProvider);
    }
    if(timeSpecifications?.length === 2){
      return joinWithConjunction(timeSpecifications.map(x => ApiProjectModel.getTimeSpecificationShortName(x, this.localeDataProvider) ?? ""), this.localeDataProvider.locale);
    }
    return `${ApiProjectModel.getTimeSpecificationShortName(timeSpecifications[0], this.localeDataProvider)}, ${ApiProjectModel.getTimeSpecificationShortName(timeSpecifications[1], this.localeDataProvider)}...`;
  }

  needTimeSpecificationPlusIcons(timeSpecifications: ApplicationModelsApiModelsApiTimeSpecification[]) {
    return timeSpecifications.length > 2;
  }

  getTimeSpecificationPlusIconCount(timeSpecifications: ApplicationModelsApiModelsApiTimeSpecification[]) {
    return timeSpecifications.length - 2;
  }

  getTimeSpecificationTooltipContent(project: ApiProjectModel) {
    return joinWithConjunction(project.timeSpecifications.slice(2).map(x => ApiProjectModel.getTimeSpecificationShortName(x, this.localeDataProvider) ?? ""), this.localeDataProvider.locale)
  }

  getTagText(project: ApiProjectModel) {
    const tags = project.tags;
    if((tags?.length ?? 0) === 0){
      return "";
    }
    if(tags?.length === 1){
      return project.getTagShortName(tags[0], this.currentLang);
    }
    if(tags?.length === 2){
      return joinWithConjunction(tags.map(x => project.getTagShortName(x, this.currentLang) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getTagShortName(tags[0], this.currentLang)}, ${project.getTagShortName(tags[1], this.currentLang)}...`;
  }

  needTagPlusIcons(tags: ApplicationModelsApiModelsApiProjectTag[]) {
    return tags.length > 2;
  }

  getTagPlusIconCount(tags: ApplicationModelsApiModelsApiProjectTag[]) {
    return tags.length - 2;
  }

  getTagTooltipContent(project: ApiProjectModel) {
    return joinWithConjunction(project.tags.slice(2).map(x => project.getTagShortName(x, this.currentLang) ?? ""), this.localeDataProvider.locale)
  }

  getRequirementPersonText(project: ApiProjectModel) {
    const requirementSpecificationPersonsFlat = project.requirementSpecificationPersonsFlat;
    if((requirementSpecificationPersonsFlat?.length ?? 0) === 0){
      return "";
    }
    if(requirementSpecificationPersonsFlat?.length === 1){
      return project.getRequirementSpecificationPersonShortName(requirementSpecificationPersonsFlat[0], this.currentLang);
    }
    if(requirementSpecificationPersonsFlat?.length === 2){
      return joinWithConjunction(requirementSpecificationPersonsFlat.map(x => project.getRequirementSpecificationPersonShortName(x, this.currentLang) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getRequirementSpecificationPersonShortName(requirementSpecificationPersonsFlat[0], this.currentLang)}, ${project.getRequirementSpecificationPersonShortName(requirementSpecificationPersonsFlat[1], this.currentLang)}...`;
  }

  getRequirementMaterialText(project: ApiProjectModel) {
    const requirementSpecificationMaterialsFlat = project.requirementSpecificationMaterialsFlat;
    if((requirementSpecificationMaterialsFlat?.length ?? 0) === 0){
      return "";
    }
    if(requirementSpecificationMaterialsFlat?.length === 1){
      return project.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterialsFlat[0], this.currentLang);
    }
    if(requirementSpecificationMaterialsFlat?.length === 2){
      return joinWithConjunction(requirementSpecificationMaterialsFlat.map(x => project.getRequirementSpecificationMaterialShortName(x, this.currentLang) ?? ""), this.localeDataProvider.locale);
    }
    return `${project.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterialsFlat[0], this.currentLang)}, ${project.getRequirementSpecificationMaterialShortName(requirementSpecificationMaterialsFlat[1], this.currentLang)}...`;
  }
  
  getRequirementMoneyText(project: ApiProjectModel) {
    const requirementSpecificationMoneySummed = project.requirementSpecificationMoneySummed;
    if(!requirementSpecificationMoneySummed){
      return "";
    }
    return project.getRequirementSpecificationMoneyShortName(requirementSpecificationMoneySummed, this.localeDataProvider);
  }

  projectUrl(entityId: string) {
    return HomeRouteNames.ProjectUrl(entityId);
  }
  editProjectUrl(entityId: string) {
    return RestrictedRouteNames.UpdateProjectUrl(entityId);
  }

  rejectProject(entityId: string) {
    this.dialog.open(RejectProjectDialogComponent, {
      data: {
        onSubmit: (rejectReason: string) => {
          this.apiService.webApiEndpointsPutProjectApprovalStatus(ObjectCreator.Create<ApplicationPutProjectApprovalStatusPutProjectApprovalStatusPutProjectApprovalStatusRequest>({
            data: {
              approvalStatus: "Rejected",
              reason: rejectReason,
            }
          }), entityId).pipe(catchError((error) => {
            alert(this.translateService.instant("messages.error-message-on-rejecting-project"));
            throw error;
          })).subscribe((response) => {
            this.projects = this.projects.filter(x => x.project?.entityId !== entityId);
          });
        }
      }
    });
  }
  approveProject(entityId: string) {
    this.apiService.webApiEndpointsPutProjectApprovalStatus(ObjectCreator.Create<ApplicationPutProjectApprovalStatusPutProjectApprovalStatusPutProjectApprovalStatusRequest>({
      data: {
        approvalStatus: "Approved",
        reason: "",
      }
    }), entityId).pipe(catchError((error) => {
      alert(this.translateService.instant("messages.error-message-on-approving-project"));
      throw error;
    })).subscribe((response) => {
      this.projects = this.projects.filter(x => x.project?.entityId !== entityId);
    });
  }
}
