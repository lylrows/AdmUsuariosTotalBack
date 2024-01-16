using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class EvaluationDetailCompentenciasDto
    {
        public int nid_evaluation { get; set; }
        public string fecha_ini { get; set; }
        public string fecha_fin { get; set; }
        public string competencia { get; set; }
        public decimal expectativa { get; set; }
        public decimal e1_auto_evaluacion { get; set; }
        public decimal e1_eval_inicial { get; set; }
        public decimal e2_verificacion { get; set; }
        public decimal e3_eval_final { get; set; }
        public string plan_accion { get; set; }
        public string indicador { get; set; }
        

    }
}
