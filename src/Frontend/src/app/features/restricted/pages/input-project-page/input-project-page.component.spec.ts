import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputProjectPageComponent } from './input-project-page.component';

describe('InputProjectPageComponent', () => {
  let component: InputProjectPageComponent;
  let fixture: ComponentFixture<InputProjectPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputProjectPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputProjectPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
