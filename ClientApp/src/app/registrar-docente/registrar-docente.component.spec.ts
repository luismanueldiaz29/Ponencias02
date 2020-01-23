import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarDocenteComponent } from './registrar-docente.component';

describe('RegistrarDocenteComponent', () => {
  let component: RegistrarDocenteComponent;
  let fixture: ComponentFixture<RegistrarDocenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrarDocenteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarDocenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
