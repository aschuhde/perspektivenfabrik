import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavigationBarFullComponent } from './navigation-bar-full.component';

describe('NavigationBarFullComponent', () => {
  let component: NavigationBarFullComponent;
  let fixture: ComponentFixture<NavigationBarFullComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NavigationBarFullComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavigationBarFullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
