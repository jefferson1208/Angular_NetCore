import { CotacaoComponent } from './cotacao.component';
import { async, TestBed } from '@angular/core/testing';
import { CotacaoService } from 'src/app/services/cotacao/cotacao.service';
import { HttpClientModule } from '@angular/common/http';
import { Guid } from 'guid-typescript';
import { BaseService } from 'src/app/services/api/base.service';
import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterTestingModule } from '@angular/router/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


const calculoFake: any = {
    custoPlanoId: Guid.create(),
    planoId: Guid.create(),
    tempoCliente: 120,
    custoPlano: 120,
    custoSemPlano: 290
};

describe('Teste do componente de Cotacao', () => {


    let service: CotacaoService;
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                HttpClientModule,
                RouterTestingModule,
                FormsModule,
                ReactiveFormsModule
            ],
            declarations: [
                CotacaoComponent
            ],
            providers: [CotacaoService],
            schemas: [CUSTOM_ELEMENTS_SCHEMA]
        }).compileComponents();
    }));

    it('Deve criar o formulário', () => {
        const fixture = TestBed.createComponent(CotacaoComponent);
        const app = fixture.componentInstance;
        app.criarForm();
        expect(app.cotacao).toBeDefined();
    });


});