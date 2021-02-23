import { Guest } from "../../models/guests";
import Layout from "../../components/Layout";
import { getGuests, createGuest } from "../../models/guests";
import { FormEvent, useState, useEffect } from "react";
import { flashError } from "../../utils";
import styled from "styled-components";

const Label = styled.label`
  margin-right: 1rem;
`;

const Input = styled.input`
  margin-left: 0.5rem;
`;

const SubmitButton = styled.input`
  background-color: #090;
  color: #fff;
  border: none;
  padding: 0.5rem 1rem;
`;

const GuestBook = () => {
  const [guests, setGuests] = useState<Guest[]>([]);

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [submitting, setSubmitting] = useState(false);

  const loadGuests = async () => {
    try {
      const items = await getGuests();
      setGuests(items);
    } catch (e) {
      flashError(e);
    }
  };

  const resetForm = () => {
    setFirstName("");
    setLastName("");
  };

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    setSubmitting(true);
    try {
      await createGuest(firstName, lastName);
      resetForm();
    } catch (e) {
      flashError(e);
    }
    setSubmitting(false);
    await loadGuests();
  };

  useEffect(() => {
    loadGuests();
  }, []);

  return (
    <Layout title="Guest Book">
      <h1>Guest Book 📖</h1>
      <ul>
        {guests.map((i) => (
          <li key={i.id}>
            {i.firstName} {i.lastName}
          </li>
        ))}
      </ul>
      <form onSubmit={handleSubmit}>
        <Label>
          First Name:
          <Input
            type="text"
            name="firstName"
            disabled={submitting}
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />
        </Label>
        <Label>
          Last Name:
          <Input
            type="text"
            name="lastName"
            disabled={submitting}
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />
        </Label>
        <SubmitButton type="submit" value="Submit" disabled={submitting} />
      </form>
    </Layout>
  );
};

export default GuestBook;
