import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { fromEvent, Observable, Subscription } from "rxjs";
import { CalculoPlano } from "src/app/models/calculoPlano";
import { CustoPlano } from "src/app/models/custoPlano";
import { PlanosDisponiveis } from "src/app/models/planosDisponiveis";
import { CotacaoService } from "src/app/services/cotacao/cotacao.service";

@Component({
    selector: 'cotacao',
    templateUrl: './cotacao.component.html',
    styleUrls: ['./../../app.component.css']

})

export class CotacaoComponent implements OnInit {

    cotacao: FormGroup;
    custoPlanos: Observable<CustoPlano[]>;
    planosDisponiveis: Observable<PlanosDisponiveis[]>;
    isLoading: boolean = false;
    padding = 'padding-top: 5%';
    isMobile: boolean = false;
    resizeObservable$: Observable<Event>
    resizeSubscription$: Subscription
    custoSemPlano: number;
    custoPlano: number;
    constructor(private fb: FormBuilder, private cotacaoService: CotacaoService) { }

    ngOnInit(): void {

        this.resizeObservable$ = fromEvent(window, 'resize')
        this.resizeSubscription$ = this.resizeObservable$.subscribe(evt => {
            this.validarTelaMobilie();
        });

        this.validarTelaMobilie();
        this.custoPlanos = this.cotacaoService.buscarCustoPlanos();
        this.planosDisponiveis = this.cotacaoService.buscarPlanosDisponiveis();

        this.criarForm();
    }

    criarForm() {
        this.cotacao = this.fb.group({
            custoPlano: ['', [Validators.required]],
            plano: ['', [Validators.required]],
            tempoCliente: [0, [Validators.required, Validators.min(1)]],
        });
    }

    observer: any = {
        next: (sucess) => { this.validarCalculo(sucess, true) },
        error: (err) => { this.validarCalculo(err) },
        complete: () => { this.isLoading = false; }
    };

    async calcular() {
        this.isLoading = true;

        let entity = {
            custoPlanoId: this.cotacao.value.custoPlano.id,
            planoId: this.cotacao.value.plano.id,
            tempoCliente: this.cotacao.value.tempoCliente
        } as CalculoPlano;

        await this.delay(2000);

        let calcular = this.cotacaoService.calcularPrecoPlano(entity);

        calcular.subscribe(this.observer);


    }

    delay(ms: number) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }

    validarTelaMobilie() {
        if (window.innerWidth < 700) {
            this.isMobile = true;
        } else {
            this.isMobile = false;
        }
    }

    limparForm() {
        this.cotacao.reset();
    }

    validarCalculo(data: any, sucess?: boolean) {
        if (sucess) {

            this.custoSemPlano = data.custoSemPlano;
            this.custoPlano = data.custoPlano;
            this.visualizarResultado = true;
        } else {
            this.isLoading = false;
            //tratar erro aqui
        }
    }

    visualizarResultado = false;
    ocultarResutado() {
        this.visualizarResultado = false;
    }
}

