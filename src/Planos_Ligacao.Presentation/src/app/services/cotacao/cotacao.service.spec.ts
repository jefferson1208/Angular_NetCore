import { HttpClientModule } from "@angular/common/http";
import { CUSTOM_ELEMENTS_SCHEMA } from "@angular/core";
import { async, TestBed } from "@angular/core/testing";
import { RouterTestingModule } from "@angular/router/testing";
import { Guid } from "guid-typescript";
import { doesNotReject } from "node:assert";
import { of } from "rxjs";
import { toArray } from "rxjs/operators";
import { CalculoPlano } from "src/app/models/calculoPlano";
import { CustoPlano } from "src/app/models/custoPlano";
import { PlanosDisponiveis } from "src/app/models/planosDisponiveis";
import { BaseService } from "../api/base.service";
import { CotacaoService } from "./cotacao.service";

export class MockBaseService {
}

const planosDisponives: PlanosDisponiveis[] = [
    {
        id: Guid.createEmpty(),
        nomePlano: 'Fale Mais 30',
        tempoPlano: 30
    },
    {
        id: Guid.createEmpty(),
        nomePlano: 'Fale Mais 60',
        tempoPlano: 60
    }
]

const planosDisponiveis$ = of([
    {
        id: Guid.createEmpty(),
        nomePlano: 'Fale Mais 30',
        tempoPlano: 30
    },
    {
        id: Guid.createEmpty(),
        nomePlano: 'Fale Mais 60',
        tempoPlano: 60
    }
])

const custoPlanos: CustoPlano[] = [
    {
        id: Guid.createEmpty(),
        origem: '011',
        destino: '018',
        custoMinuto: 1.9
    },
    {
        id: Guid.createEmpty(),
        origem: '018',
        destino: '011',
        custoMinuto: 2.7
    }
]

const custoPlanos$ = of([
    {
        id: Guid.createEmpty(),
        origem: '011',
        destino: '018',
        custoMinuto: 1.9
    },
    {
        id: Guid.createEmpty(),
        origem: '018',
        destino: '011',
        custoMinuto: 2.7
    }
])

const calculoPlano$ = of(
    {
        custoPlanoId: Guid.createEmpty(),
        planoId: Guid.createEmpty(),
        tempoCliente: 30,
        custoPlano: 0,
        custoSemPlano: 38.00
    }
)

const calculoPlano: CalculoPlano =
{
    custoPlanoId: Guid.createEmpty(),
    planoId: Guid.createEmpty(),
    tempoCliente: 30,
    custoPlano: 0,
    custoSemPlano: 38.00
};

describe('Teste do serviço de cotação', () => {


    let service: CotacaoService;
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            imports: [
                RouterTestingModule,
                HttpClientModule,

            ],

            providers: [CotacaoService, { provide: BaseService, useClass: MockBaseService }],
            schemas: [CUSTOM_ELEMENTS_SCHEMA]
        }).compileComponents();

        service = TestBed.inject(CotacaoService);


    }));



    it('Deve retornar uma lista de planos disponíveis', () => {

        spyOn(service, 'buscarPlanosDisponiveis').and.returnValue(planosDisponiveis$);

        let result = service.buscarPlanosDisponiveis();

        result.subscribe((r: any) => {
            expect(r).toBeDefined();
            expect(r[0]).toEqual(planosDisponives[0]);
            expect(r).toEqual(planosDisponives);
        })

    });

    it('Deve retornar uma lista de custos dos planos', () => {
        spyOn(service, 'buscarCustoPlanos').and.returnValue(custoPlanos$);

        let result = service.buscarCustoPlanos();

        result.subscribe((r: any) => {
            expect(r).toBeDefined();
            expect(r[0]).toEqual(custoPlanos[0]);
            expect(r).toEqual(custoPlanos);
        })
    });



    it('Deve calcular o custo de um determinado plano', () => {
        spyOn(service, 'calcularPrecoPlano').and.returnValue(calculoPlano$);

        let result = service.calcularPrecoPlano(null);

        result.subscribe((r: any) => {
            expect(r).toBeDefined();
            expect(r[0]).toEqual(calculoPlano[0]);
            expect(r).toEqual(calculoPlano);
        })

    });
});



