import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarMovimentacaoComponent } from './adicionar-movimentacao.component';

describe('AdicionarMovimentacaoComponent', () => {
  let component: AdicionarMovimentacaoComponent;
  let fixture: ComponentFixture<AdicionarMovimentacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdicionarMovimentacaoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdicionarMovimentacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
