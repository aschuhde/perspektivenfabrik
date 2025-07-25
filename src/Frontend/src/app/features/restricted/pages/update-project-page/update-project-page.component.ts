import {Component, inject} from '@angular/core';
import {ProjectInput} from "../../models/project-input";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {InputProjectComponent} from "../../components/input-project/input-project.component";
import {ActivatedRoute, Router} from "@angular/router";
import {ApiService} from "../../../../server/api/api.service";
import {ApplicationModelsApiModelsApiProject} from "../../../../server/model/applicationModelsApiModelsApiProject";
import {ProjectSaveContext} from "../../models/project-save-context";
import { RestrictedRouteNames } from '../../restricted-route-names';
import {isServer} from "../../../../shared/tools/server-tools";
import { catchError, of, throwError } from 'rxjs';
import { MatDialog } from "@angular/material/dialog";
import {MessageDialogComponent} from "../../../../shared/dialogs/message-dialog/message-dialog.component";
import {MessageDialogData} from "../../../../shared/models/message-dialog-data";
import {TranslateService} from "@ngx-translate/core"
import {handleProjectSaveErrorAndGetDialogData} from "../../tools/error-handling";
import {Language} from "../../../../core/types/general-types";
import {BASE_PATH} from "../../../../server/variables";

@Component({
  selector: 'app-update-project-page',
  imports: [NavigationBarFullComponent, InputProjectComponent],
  templateUrl: './update-project-page.component.html',
  styleUrl: './update-project-page.component.scss'
})
export class UpdateProjectPageComponent {
  readonly dialog = inject(MatDialog);
  translateService = inject(TranslateService)
  projectInput: ProjectInput = new ProjectInput(() => this.translateService.currentLang as Language);
  projectIdentifier: string = inject(ActivatedRoute).snapshot.paramMap.get("projectIdentifier") ?? "";
  apiService = inject(ApiService)
  project: ApplicationModelsApiModelsApiProject | null = null
  isLoading: boolean = true;
  projectSaveContext: ProjectSaveContext = new ProjectSaveContext();
  apiBasePath = inject(BASE_PATH);
  router = inject(Router);
  
  loadProject(){
    if(isServer()) return;
    
    const projectResponse = this.apiService.webApiEndpointsGetUsersProject(this.projectIdentifier);

    projectResponse.subscribe(x => {
      if((x as any).project){
        this.projectInput.loadFromProject((x as any).project, this.translateService.currentLang as Language, this.apiBasePath);
        this.projectInput.buildRequest(this.translateService.currentLang as Language).then((x) => {
            this.projectSaveContext.hasChanges = false;
            this.projectSaveContext.lastSavedProjectRequest = x;
            this.projectSaveContext.onChange(this.projectInput, this.translateService.currentLang as Language);
        })
        this.isLoading = false;
      }
    });
  }

  ngOnInit(){
    this.loadProject();
  }

  async sendRequest(){
    this.projectSaveContext.isSaving = true;
    this.projectSaveContext.madeChangesWhileSaving = false;
    const projectRequest = await this.projectInput.buildRequest(this.translateService.currentLang as Language) 
    this.apiService.webApiEndpointsPutProject({
      project: projectRequest,         
    }, this.projectIdentifier).pipe(catchError((err) => {
      this.projectSaveContext.isSaving = false;
      handleProjectSaveErrorAndGetDialogData(err, this.dialog, this.translateService, projectRequest, "Update Project");
    })).subscribe(x => {
      this.projectSaveContext.isSaving = false;
      this.projectSaveContext.lastSave = new Date();
      this.projectSaveContext.lastSavedProjectRequest = projectRequest;
      if(!this.projectSaveContext.madeChangesWhileSaving) {
          this.projectSaveContext.hasChanges = false;
      }
    });
  }
  
  onSave() {
    this.sendRequest();
  }

  onDelete() {
    this.apiService.webApiEndpointsDeleteProject({}, this.projectIdentifier).subscribe(x => {
      this.router.navigateByUrl(RestrictedRouteNames.MyProjectsUrl()).then();
    });
  }
}
