import React, { useState, useEffect } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { getCart, processPayment } from '../apiService';

const PaymentPage = () => {
  const [cardNumber, setCardNumber] = useState('');
  const [cardHolderName, setCardHolderName] = useState('');
  const [expiryDate, setExpiryDate] = useState('');
  const [cvv, setCvv] = useState('');
  const [paymentResult, setPaymentResult] = useState('');
  const [errors, setErrors] = useState({});
  const [cart, setCart] = useState({ cartId: null, tickets: [] });
  const { cartId } = useParams();
  const customerId = 1;

  const navigate = useNavigate();

  useEffect(() => {
    getCart(cartId)
      .then((data) => {
        console.log("Cart Data:", data);
        setCart(data);
      })
      .catch((error) => console.error("Failed to fetch cart data:", error));
  }, [cartId]);

  const totalAmount = cart.tickets.reduce((acc, ticket) => acc + ticket.quantity * ticket.price, 0);
  const totalWithTaxes = totalAmount * 0.07 + totalAmount;

  const validateCardNumber = (number) => /^\d{4}-\d{4}-\d{4}-\d{4}$/.test(number);
  const validateExpiryDate = (date) => /^\d{2}\/\d{2}$/.test(date);
  const validateCVV = (cvvValue) => /^\d{3}$/.test(cvvValue);

  const handleSubmit = async (e) => {
    e.preventDefault();
    const newErrors = {};

    if (!validateCardNumber(cardNumber)) newErrors.cardNumber = 'Invalid card number. Format should be 1234-1234-1234-1234.';
    if (!cardHolderName.trim()) newErrors.cardHolderName = 'Card holder name cannot be empty.';
    if (!validateExpiryDate(expiryDate)) newErrors.expiryDate = 'Invalid expiry date. Format should be MM/YY.';
    if (!validateCVV(cvv)) newErrors.cvv = 'Invalid CVV. Must be exactly 3 digits.';

    if (Object.keys(newErrors).length > 0) {
      setErrors(newErrors);
      return;
    }

    try {

      const cartId = cart.cartId;
      const customerId = 1;
      const paymentInfo = {
        cardNumber,
        cardHolderName,
        expiryDate,
        cvv,
      };

      console.log("Payment Info:", paymentInfo);
      

      const result = await processPayment(cartId, customerId, paymentInfo);

      setPaymentResult('Payment successful! Thank you for your purchase.');
      console.log("Payment Result:", result);

    } catch (error) {
      console.error("Payment failed:", error);
      setPaymentResult('Payment failed. Please try again.');
    }
  };

  return (
    <div className="checkout-container">
      <h1>QuikTix Checkout</h1>

      <div className="cart-summary">
        <h2>Cart Summary</h2>
        <p>Total Cost: ${totalAmount.toFixed(2)}</p>
        <p>Total Cost with Taxes: ${(totalWithTaxes).toFixed(2)}</p>
      </div>

      <h3>Enter Payment Details</h3>

      <form onSubmit={handleSubmit} id="paymentForm">
        <div className="input-group">
          <label htmlFor="cardNumber">Card Number:</label>
          <input
            type="text"
            id="cardNumber"
            value={cardNumber}
            onChange={(e) => setCardNumber(e.target.value)}
            placeholder="1234-1234-1234-1234"
            required
          />
          {errors.cardNumber && <span className="error">{errors.cardNumber}</span>}
        </div>

        <div className="input-group">
          <label htmlFor="cardHolderName">Card Holder Name:</label>
          <input
            type="text"
            id="cardHolderName"
            value={cardHolderName}
            onChange={(e) => setCardHolderName(e.target.value)}
            required
          />
          {errors.cardHolderName && <span className="error">{errors.cardHolderName}</span>}
        </div>

        <div className="input-group">
          <label htmlFor="expiryDate">Expiry Date (MM/YY):</label>
          <input
            type="text"
            id="expiryDate"
            value={expiryDate}
            onChange={(e) => setExpiryDate(e.target.value)}
            placeholder="MM/YY"
            required
          />
          {errors.expiryDate && <span className="error">{errors.expiryDate}</span>}
        </div>

        <div className="input-group">
          <label htmlFor="cvv">CVV:</label>
          <input
            type="text"
            id="cvv"
            value={cvv}
            onChange={(e) => setCvv(e.target.value)}
            placeholder="123"
            required
          />
          {errors.cvv && <span className="error">{errors.cvv}</span>}
        </div>

        <button type="submit" id="submitBtn">Submit Payment</button>
      </form>

      {paymentResult && <div className="payment-result">{paymentResult}</div>}

      <button id="exitBtn" onClick={() => navigate(`/customer/${customerId}`)}>Exit</button>
    </div>
  );
};

export default PaymentPage;
