import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { CotacaoComponent } from "./cotacao.component";
import { CotacaoAppComponent } from "./CotacaoAppComponent";

const cotacaoRouterConfig: Routes = [
    {
        path: '', component: CotacaoAppComponent,
        children: [
            {
                path: '',
                component: CotacaoComponent,
            }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(cotacaoRouterConfig),

    ],
    exports: [RouterModule]
})
export class CotacaoRoutingModule { }