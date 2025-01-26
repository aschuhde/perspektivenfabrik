import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InputProjectTimeComponent } from './input-project-time.component';

describe('InputProjectTimeComponent', () => {
  let component: InputProjectTimeComponent;
  let fixture: ComponentFixture<InputProjectTimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [InputProjectTimeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InputProjectTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
