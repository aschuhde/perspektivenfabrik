import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../../../../server/api/api.service';
import { ApplicationModelsApiModelsApiProject } from '../../../../server/model/applicationModelsApiModelsApiProject';
import { ProjectDetailComponent } from '../../components/project-detail/project-detail.component';
import { NavigationBarFullComponent } from '../../../../shared/components/navigation-bar-full/navigation-bar-full.component';

@Component({
  selector: 'app-project-detail-page',
  imports: [ProjectDetailComponent, NavigationBarFullComponent],
  templateUrl: './project-detail-page.component.html',
  styleUrl: './project-detail-page.component.scss'
})
export class ProjectDetailPageComponent {
  projectIdentifier: string = inject(ActivatedRoute).snapshot.paramMap.get("projectIdentifier") ?? "";
  apiService = inject(ApiService)
  project: ApplicationModelsApiModelsApiProject | null = null
  loadProject(){
    const projectResponse = this.apiService.webApiEndpointsGetProject(this.projectIdentifier);

    projectResponse.subscribe(x => {
      if((x as any).project){
        this.project = (x as any).project;
      }
    });
  }

  ngOnInit(){
    this.loadProject();
  }
}
