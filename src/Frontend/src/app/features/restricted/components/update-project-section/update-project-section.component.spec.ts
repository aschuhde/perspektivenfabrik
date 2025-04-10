import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateProjectSectionComponent } from './update-project-section.component';

describe('UpdateProjectSectionComponent', () => {
  let component: UpdateProjectSectionComponent;
  let fixture: ComponentFixture<UpdateProjectSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateProjectSectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateProjectSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
