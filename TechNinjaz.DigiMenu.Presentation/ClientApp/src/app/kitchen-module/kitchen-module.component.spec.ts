import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KitchenModuleComponent } from './kitchen-module.component';

describe('KitchenModuleComponent', () => {
  let component: KitchenModuleComponent;
  let fixture: ComponentFixture<KitchenModuleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KitchenModuleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KitchenModuleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
