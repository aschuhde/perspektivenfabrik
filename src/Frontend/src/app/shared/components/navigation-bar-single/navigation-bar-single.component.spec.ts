import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationBarSingleComponent } from './navigation-bar-single.component';

describe('NavigationBarSingleComponent', () => {
  let component: NavigationBarSingleComponent;
  let fixture: ComponentFixture<NavigationBarSingleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavigationBarSingleComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavigationBarSingleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
