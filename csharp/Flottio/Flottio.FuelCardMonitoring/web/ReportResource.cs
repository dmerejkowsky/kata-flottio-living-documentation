using Flottio.FuelCardMonitoring.Domain;
using Flottio.FuelCardMonitoring.Infra;
using System;
using System.Collections.Generic;

namespace FuelCardMonitoring.Infra.web
{
    /**
     * The REST resource
     */
    public class ReportResource
    {

        // @XmlSerializable etc.
        // DTO for Jackson
        public class Report
        {
            private String status;
            private String transactionId;
            private List<String> issues;
        }

        private ReportDAO dao;

        // GET etc.
        public List<Report> get(DateTime date)
        {
            List<FuelCardTransactionReport> reports = dao.findAll(date);
            List<Report> jsonReports = new List<Report>();
            foreach (FuelCardTransactionReport report in reports)
            {
                jsonReports.Add(translate(report));
            }
            return jsonReports;
        }

        private Report translate(FuelCardTransactionReport report)
        {
            // TODO Auto-generated method stub
            return null;
        }
    }
}