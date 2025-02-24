import {Component, inject} from '@angular/core';
import {ProjectInput} from "../../models/project-input";
import {
  NavigationBarFullComponent
} from "../../../../shared/components/navigation-bar-full/navigation-bar-full.component";
import {InputProjectComponent} from "../../components/input-project/input-project.component";
import {ActivatedRoute} from "@angular/router";
import {ApiService} from "../../../../server/api/api.service";
import {ApplicationModelsApiModelsApiProject} from "../../../../server/model/applicationModelsApiModelsApiProject";

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
  loadProject(){
    const projectResponse = this.apiService.webApiEndpointsGetProject(this.projectIdentifier);

    projectResponse.subscribe(x => {
      if((x as any).project){
        this.projectInput.loadFromProject((x as any).project);
        this.isLoading = false;
      }
    });
  }

  ngOnInit(){
    this.loadProject();
  }

  async sendRequest(){
    this.apiService.webApiEndpointsPutProject({
      project: await this.projectInput.buildRequest(),
    }, this.projectIdentifier).subscribe(x => {
      console.log("saved");
    });
  }
  
  onSave() {
    this.sendRequest();
  }
}
