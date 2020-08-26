using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using ECommerce_Application.Data;
using ECommerce_Application.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Services
{

    /// <summary>
    /// Referencing Interface Payment
    /// </summary>
    public class PaymentService : IPayment
    {
        private readonly IConfiguration _config;
        private readonly IOrder _order;
        private readonly UserManager<Customer> _userManager;

        public PaymentService(IConfiguration config, IOrder order, UserManager<Customer> userManager)
        {
            _config = config;
            _order = order;
            _userManager = userManager;
        }


        /// <summary>
        /// Authorize the credit card information
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="cardName"></param>
        /// <param name="expiration"></param>
        /// <param name="cvc"></param>
        /// <returns></returns>
        public async Task<string> Run(string userEmail, string cardName, string expiration, string cvc)
        {
            // decalred the type of environment
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            // setup our merchant account credentials
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new AuthorizeNet.Api.Contracts.V1.merchantAuthenticationType()
            {
                name = _config["AuthorizeId"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["AuthorizeKey"]
            };

            // create the card we want on file.
            // I want you to store these in your secrets file, adn choose a dropdown for the user in the checkout process

            var creditCard = new creditCardType
            {
                cardNumber = _config[cardName],
                expirationDate = expiration,
                cardCode = cvc
            };
            
            customerAddressType billingAddress = await GetsBillingAddress(userEmail);

            //declare that thuse is going to use an existing Credit Cart to pay
            var paymentType = new paymentType { Item = creditCard };

            // // make the transactionRequest

            var transRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = 150.75m,
                payment = paymentType,
                billTo = billingAddress
            };

            // made teh transaction type, now we need to make the request
            var request = new createTransactionRequest { transactionRequest = transRequest };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();
            if(response != null)
            {
                if(response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return "Success";
                }
            }


            return "Failed";
        }


        /// <summary>
        /// Get the users billing address by email
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        private async Task<customerAddressType> GetsBillingAddress(string userEmail)
        {
            // you can pull this data from teh db the individual data from the order/cart itself
            Order order = await _order.GetOrder(userEmail);
            customerAddressType address = new customerAddressType
            {
                firstName = order.FirstName,
                lastName = order.LastName,
                address = order.Address,
                city = order.City,
                zip = order.ZipCode
            };
            return address;
        }
    }
}
