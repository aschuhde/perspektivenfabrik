import {Component, inject} from '@angular/core';
import {ProjectInput} from "../../models/project-input";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {InputProjectComponent} from "../../components/input-project/input-project.component";
import {ActivatedRoute} from "@angular/router";
import {ApiService} from "../../../../server/api/api.service";
import {ApplicationModelsApiModelsApiProject} from "../../../../server/model/applicationModelsApiModelsApiProject";
import {ProjectSaveContext} from "../../models/project-save-context";
import { RestrictedRouteNames } from '../../restricted-route-names';

@Component({
  selector: 'app-update-project-page',
  imports: [NavigationBarFullComponent, InputProjectComponent],
  templateUrl: './update-project-page.component.html',
  styleUrl: './update-project-page.component.scss'
})
export class UpdateProjectPageComponent {
  projectInput: ProjectInput = new ProjectInput();
  projectIdentifier: string = inject(ActivatedRoute).snapshot.paramMap.get("projectIdentifier") ?? "";
  apiService = inject(ApiService)
  project: ApplicationModelsApiModelsApiProject | null = null
  isLoading: boolean = true;
  projectSaveContext: ProjectSaveContext = new ProjectSaveContext();
  loadProject(){
    const projectResponse = this.apiService.webApiEndpointsGetUsersProject(this.projectIdentifier);

    projectResponse.subscribe(x => {
      if((x as any).project){
        this.projectInput.loadFromProject((x as any).project);
        this.projectInput.buildRequest().then((x) => {
            this.projectSaveContext.hasChanges = false;
            this.projectSaveContext.lastSavedProjectRequest = x;
            this.projectSaveContext.onChange(this.projectInput);
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
    const projectRequest = await this.projectInput.buildRequest() 
    this.apiService.webApiEndpointsPutProject({
      project: projectRequest,         
    }, this.projectIdentifier).subscribe(x => {
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
      window.location.href = RestrictedRouteNames.UserAreaUrl();
    });
  }
}
