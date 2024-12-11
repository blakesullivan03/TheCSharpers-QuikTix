import React, { useState, useEffect } from "react";
import { getCustomerById } from "../apiService";
import { useParams } from "react-router-dom";

const CustomerDetails = ({ customerId }) => {
    const [customer, setCustomer] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    customerId = useParams().customerId;

    useEffect(() => {
        const fetchCustomerDetails = async () => {
            try {
                const response = await getCustomerById(customerId);
                setCustomer(response);
            } catch (err) {
                setError("Failed to fetch customer details.");
            } finally {
                setLoading(false);
            }
        };

        fetchCustomerDetails();
    }, [customerId]);

    if (loading) {
        return <div>Loading...</div>;
    }

    if (error) {
        return <div>{error}</div>;
    }

    if (!customer) {
        return <div>No customer found.</div>;
    }

    return (
        <div style={{ padding: "20px", fontFamily: "Arial, sans-serif" }}>
            <h1>Customer Details</h1>
            <div style={{ marginBottom: "20px" }}>
                <p><strong>Name:</strong> {customer.name}</p>
                <p><strong>Email:</strong> {customer.email}</p>
                <p><strong>Phone Number:</strong> {customer.phoneNumber}</p>
            </div>
            <h2>Tickets</h2>
            {customer.purchaseHistory && customer.purchaseHistory.length > 0 ? (
                <ul>
                    {customer.purchaseHistory.map((ticket, index) => (
                        <li key={index}>{ticket}</li>
                    ))}
                </ul>
            ) : (
                <p>No tickets found for this customer.</p>
            )}
        </div>
    );
};

export default CustomerDetails;
