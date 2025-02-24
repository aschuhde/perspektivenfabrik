import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateProjectPageComponent } from './update-project-page.component';

describe('UpdateProjectPageComponent', () => {
  let component: UpdateProjectPageComponent;
  let fixture: ComponentFixture<UpdateProjectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UpdateProjectPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UpdateProjectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
