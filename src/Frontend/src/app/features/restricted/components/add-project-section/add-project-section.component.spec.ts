import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProjectSectionComponent } from './add-project-section.component';

describe('AddProjectSectionComponent', () => {
  let component: AddProjectSectionComponent;
  let fixture: ComponentFixture<AddProjectSectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddProjectSectionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddProjectSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
