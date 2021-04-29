import { CommonModule, registerLocaleData } from "@angular/common";
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CotacaoComponent } from "./cotacao.component";
import { CotacaoRoutingModule } from "./cotacao.route";
import { CotacaoAppComponent } from "./CotacaoAppComponent";
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CotacaoService } from "src/app/services/cotacao/cotacao.service";
import { HttpClientModule } from "@angular/common/http";
import localePt from '@angular/common/locales/pt';

registerLocaleData(localePt);

@NgModule({
    declarations: [
        CotacaoAppComponent,
        CotacaoComponent,
    ],
    imports: [
        CommonModule,
        CotacaoRoutingModule,
        FormsModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        HttpClientModule

    ],
    providers: [CotacaoService],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})

export class CotacaoModule { }