import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAreaNavigationComponent } from './user-area-navigation.component';

describe('UserAreaNavigationComponent', () => {
  let component: UserAreaNavigationComponent;
  let fixture: ComponentFixture<UserAreaNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserAreaNavigationComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserAreaNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
