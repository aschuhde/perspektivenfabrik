import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TempOneComponent } from './temp-one.component';

describe('TempOneComponent', () => {
  let component: TempOneComponent;
  let fixture: ComponentFixture<TempOneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TempOneComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TempOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
