import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectFilteringComponent } from './project-filtering.component';

describe('ProjectFilteringComponent', () => {
  let component: ProjectFilteringComponent;
  let fixture: ComponentFixture<ProjectFilteringComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ProjectFilteringComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProjectFilteringComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
