using System;
using System.Collections.Generic;
using System.Text;

namespace HumanManagement.Domain.Evaluation.Dto
{
    public class EvaluationDetailObjetivosDto
    {
        public int nid_evaluation { get; set; }
        public string fecha_ini { get; set; }
        public string fecha_fin { get; set; }
        public string objetivo_puesto { get; set; }
        public string indicador { get; set; }
        public string smeta { get; set; }
        public int nmeta_porc { get; set; }
        public int npeso_porc { get; set; }
        public int e2_verificacion { get; set; }
        public int e3_eval_final { get; set; }

    }
}
