import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAreaPageComponent } from './user-area-page.component';

describe('UserAreaPageComponent', () => {
  let component: UserAreaPageComponent;
  let fixture: ComponentFixture<UserAreaPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserAreaPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UserAreaPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
