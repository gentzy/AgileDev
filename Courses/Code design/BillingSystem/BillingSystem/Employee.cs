using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillingSystem
{
    public class Employee
    {
        string m_name;
        string m_title;
        double m_billingRate; // per hour

        public Employee() { }

        public void BillCustomer(int numberOfHours, Bill customerBill)
        {
            customerBill.AddBillAmount(numberOfHours * m_billingRate);
        }
    }

    public class Client
    {
        string m_name;
        string m_billingAddress;
        double m_billingRate;
        CreditCard m_creditCard;

        public void Pay(double amount)
        {
            m_creditCard.CreditAmount(amount);
        }
    }

    public class CreditCard
    {
        string m_cardNumber;
        string m_cardType;
        string m_cardSecurityCode;

        public void CreditAmount(double amount)
        {
            // Send information to credit card server
        }
    }

    public class WorkOrder
    {
        Client client;
        Employee employee;
        int numberOfHours;
    }

    public class Bill
    {
        List<WorkOrder> workOrders;

        public double CreateTotalBill()
        {
            double total = 0;
            foreach (double amount in m_amounts)
            {
                total += amount;
            }

            return total;
        }

        public void AddBillAmount(double amount)
        {
            m_amounts.Add(amount);
        }
    }
}
