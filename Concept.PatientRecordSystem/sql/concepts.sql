DO $$
DECLARE
    LanguageConceptSet UUID := '96944ce8-a8ff-4dfa-85e3-03d18c2988ed';
	AddressUseConceptSet UUID := '1bed378b-f5ef-48a1-9581-54a0ec544177';
	NameTypeConceptSet UUID := 'a16830e3-5d77-4457-8d6e-95d30fec9b83';
	ContactSystemConceptSet UUID := '19325dc3-3a65-4c1b-a475-e54ab519dab3';
	ContactPointUseConceptSet UUID := '9df86d35-0b98-4392-a4ac-dfb571140e1e';
	GenderConceptSet UUID := 'a21c2487-a6b3-4e48-8f3a-5b32543b4411';
	IndividualTypeConceptSet UUID := '6cef0e74-82af-4734-93f1-5b08a9d9e64b';
	PractitionerReferenceTypeConceptSet UUID := '0f15cfcb-d17f-421a-9f52-615cbc7e8030';
	StatusConceptSet UUID := 'c2f94e02-3b69-4f5d-9254-7bf15d488e4e';
    IntentConceptSet UUID := '6c2c5b4f-9c62-4c3f-b64c-780546c1a5a7';


BEGIN

-- Concept Sets
INSERT INTO public."ConceptSets"("Id", "Name")
VALUES 
		( LanguageConceptSet, 'Language'), 
		( AddressUseConceptSet,'AddressUse'), 
		( NameTypeConceptSet,'NameType'), 
		( ContactSystemConceptSet,'ContactSystem'), 
		( ContactPointUseConceptSet,'ContactPointUse'),
		( GenderConceptSet, 'AdministrativeGender'),
		( IndividualTypeConceptSet, 'IndividualType'),
		( PractitionerReferenceTypeConceptSet, 'PractitionerReferenceType'),
		( StatusConceptSet, 'Status'),
        ( IntentConceptSet, 'Intent');


-- language concepts
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
	('9df86d35-0b98-4392-a4ac-dfb571140e1e', 'en', 'en', 'English'),
	('1da84595-42ac-4208-8e13-ce3a7228340b', 'es', 'es', 'Spanish'),
	('935debed-1c1c-400b-a717-a352eb0e182c', 'zh', 'zh', 'Chinese'),
	('c9f50963-0e83-4c50-b916-4b6e8e36ad79', 'fr', 'fr', 'French');	  

-- Address use concepts Contact point use concepts
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
	('c6d4c3bf-4e48-474e-af2c-90e9e1413257', 'home', 'home', 'Home'),
	('b39b2467-fc53-42ba-a737-712e2c045d82', 'work', 'work', 'Work'),
	('c2a203d2-ccd0-4ac2-9d25-caff3dd96bc1', 'temp', 'temp', 'Temp'),
	('e855520d-8ba7-4dd3-b5d8-4dc492150bde', 'old', 'old', 'Old'),
	('f32df4eb-c598-475d-82d9-c56c657dc73b', 'billing', 'billing', 'Billing'),
	('2b397cdb-cba5-4371-befe-3e9029908021', 'mobile', 'mobile', 'Mobile');

-- Contact system concepts
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
	('140076a0-a8e0-4323-a144-bc1ac83b6340', 'phone', 'phone', 'Phone'),
	('0c1b7d76-feda-47a8-9842-5a9c3e7de614', 'fax', 'fax', 'Fax'),
	('f376b83d-0f9a-4b9c-bdc3-6b22327460d3', 'email', 'email', 'Email'),
	('bcf5321b-1aab-4216-b918-fa0dddeddddd', 'pager', 'pager', 'Pager'),
	('6704e0c5-fbec-4cca-b52a-a10368bb5334', 'url', 'url', 'URL'),
	('47d7ecf0-31bb-4d9e-9f7e-7fc18b8caaab', 'sms', 'sms', 'SMS'),
	('cffc025b-aacc-4681-a49c-a242507a3b6a', 'other', 'other', 'Other');

-- gender concepts
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
	('8021552e-5980-45b1-bd8d-9b30d57e67e9', 'Male', 'male', 'Male'),
	('e35e3734-7767-47ae-8f32-a682907f682d', 'Female', 'female', 'Female'),
	('0893a08c-d67d-429e-8e38-d497bc2e9716', 'Other', 'other', 'Other'),
	('cb679791-ae0b-442a-ba75-6bd94fcf89dd', 'Unknown', 'unknown', 'Unknown');	

-- name types
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES
	('166daa19-2148-4d4d-991d-f6f9e83203c0', 'Family', 'family', 'Family'),
	('05646cc6-b67f-4caa-be05-67b3e0bd6fe9', 'Given', 'given', 'Given');

-- Practioner reference types
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES
	('80ad8e8f-34c3-42bb-84d8-c59db8348bf7', 'Organization', 'organization', 'Organization'),
	('77f1f45b-861f-4183-9f4f-e8529e45b38f', 'Practitioner', 'practitioner', 'Practitioner'),
	('6b40d73f-5a20-4de3-9ef0-60bfab08d31e', 'PractitionerRole', 'practitionerRole', 'PractitionerRole');

-- Individual type concepts
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
	('0582e424-c9c0-4e6b-a922-0dd16fb68aea', 'patient', 'patient', 'Patient'),
	('4297af86-e72d-4768-89c6-dfb9af9f84d0', 'practitioner', 'practitioner', 'Practitioner');

-- Insert Status Concepts with hardcoded UUIDs
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
    ('dfeab3cc-3d73-4d93-89a4-5db9753e1f9f', 'draft', 'draft', 'Draft'),
    ('946b7d3c-9c12-4bb8-9d3a-8f5b7e78d2f3', 'active', 'active', 'Active'),
    ('72ef2b5e-8e25-473a-a78c-d3120f4c913a', 'on-hold', 'on-hold', 'On Hold'),
    ('a5b3e865-3c0b-4a4e-9b39-bdd8ff6c0cf7', 'revoked', 'revoked', 'Revoked'),
    ('0cdd69f5-4b9b-403e-b8cb-d6a5af5f8203', 'completed', 'completed', 'Completed'),
    ('3a7958b4-8a4d-4d5b-8ff4-d78c8ab07e53', 'entered-in-error', 'entered-in-error', 'Entered In Error'),
    ('28d51738-3a60-4a4e-8f5b-d61e5c7c1a79', 'unknown', 'unknown', 'Unknown');

-- Insert Intent Concepts with hardcoded UUIDs
INSERT INTO public."Concepts"("Id", "Value", "Code", "Display")
VALUES 
    ('bc1f6a17-4a4e-4f5b-9b39-c67f68c6d3f4', 'proposal', 'proposal', 'Proposal'),
    ('26e5a784-8a6b-4f8b-9f5b-7e5f3a6b789a', 'plan', 'plan', 'Plan'),
    ('e1f5d2b9-4c0b-4f5c-9d3a-6b5f5c7e3a8b', 'directive', 'directive', 'Directive'),
    ('9b3e6f5b-8a4d-4f8c-9b3a-8c7f5b3a6d1e', 'order', 'order', 'Order'),
    ('58f6d1c8-4b9b-4f5a-9b3a-d5f3a5b8e4a7', 'original-order', 'original-order', 'Original Order'),
    ('d7a4b6c9-4c5b-4d5a-9f5b-7e5b8a6f7e3a', 'reflex-order', 'reflex-order', 'Reflex Order'),
    ('a8f5b7c8-4d5b-4f5a-9b3a-6d7f5e3a8b9c', 'filler-order', 'filler-order', 'Filler Order'),
    ('c9e5d6f1-4b7b-4f5c-9b3a-8d7f5c6a3e5a', 'instance-order', 'instance-order', 'Instance Order'),
    ('8f5b7e6d-4f8b-4d5a-9b3a-7c5f3a8b6d1e', 'option', 'option', 'Option');

 -- Concept Concept Set 
INSERT INTO public."ConceptConceptSet"("Id", "ConceptId", "ConceptSetId")
VALUES 
    (gen_random_uuid(), '9df86d35-0b98-4392-a4ac-dfb571140e1e', LanguageConceptSet),
    (gen_random_uuid(), '1da84595-42ac-4208-8e13-ce3a7228340b', LanguageConceptSet),
    (gen_random_uuid(),'935debed-1c1c-400b-a717-a352eb0e182c', LanguageConceptSet),
    (gen_random_uuid(),'c9f50963-0e83-4c50-b916-4b6e8e36ad79', LanguageConceptSet),
    (gen_random_uuid(),'c6d4c3bf-4e48-474e-af2c-90e9e1413257', AddressUseConceptSet),
    (gen_random_uuid(),'b39b2467-fc53-42ba-a737-712e2c045d82', AddressUseConceptSet),
    (gen_random_uuid(),'c2a203d2-ccd0-4ac2-9d25-caff3dd96bc1', AddressUseConceptSet),
    (gen_random_uuid(),'e855520d-8ba7-4dd3-b5d8-4dc492150bde', AddressUseConceptSet),
    (gen_random_uuid(),'f32df4eb-c598-475d-82d9-c56c657dc73b', AddressUseConceptSet),
    (gen_random_uuid(),'c6d4c3bf-4e48-474e-af2c-90e9e1413257', ContactPointUseConceptSet),
    (gen_random_uuid(),'b39b2467-fc53-42ba-a737-712e2c045d82', ContactPointUseConceptSet),
    (gen_random_uuid(),'c2a203d2-ccd0-4ac2-9d25-caff3dd96bc1', ContactPointUseConceptSet),
    (gen_random_uuid(),'e855520d-8ba7-4dd3-b5d8-4dc492150bde', ContactPointUseConceptSet),
    (gen_random_uuid(),'f32df4eb-c598-475d-82d9-c56c657dc73b', ContactPointUseConceptSet),
    (gen_random_uuid(),'2b397cdb-cba5-4371-befe-3e9029908021', ContactPointUseConceptSet),
    (gen_random_uuid(),'140076a0-a8e0-4323-a144-bc1ac83b6340', ContactSystemConceptSet),
    (gen_random_uuid(),'0c1b7d76-feda-47a8-9842-5a9c3e7de614', ContactSystemConceptSet),
    (gen_random_uuid(),'f376b83d-0f9a-4b9c-bdc3-6b22327460d3', ContactSystemConceptSet),
    (gen_random_uuid(),'bcf5321b-1aab-4216-b918-fa0dddeddddd', ContactSystemConceptSet),
    (gen_random_uuid(),'6704e0c5-fbec-4cca-b52a-a10368bb5334', ContactSystemConceptSet),
    (gen_random_uuid(),'47d7ecf0-31bb-4d9e-9f7e-7fc18b8caaab', ContactSystemConceptSet),
    (gen_random_uuid(),'cffc025b-aacc-4681-a49c-a242507a3b6a', ContactSystemConceptSet),
	(gen_random_uuid(), '8021552e-5980-45b1-bd8d-9b30d57e67e9', GenderConceptSet),
	(gen_random_uuid(), 'e35e3734-7767-47ae-8f32-a682907f682d', GenderConceptSet),
	(gen_random_uuid(), '0893a08c-d67d-429e-8e38-d497bc2e9716', GenderConceptSet),
	(gen_random_uuid(), 'cb679791-ae0b-442a-ba75-6bd94fcf89dd', GenderConceptSet),
	(gen_random_uuid(), '166daa19-2148-4d4d-991d-f6f9e83203c0', NameTypeConceptSet),
	(gen_random_uuid(), '05646cc6-b67f-4caa-be05-67b3e0bd6fe9', NameTypeConceptSet),
	(gen_random_uuid(),'0582e424-c9c0-4e6b-a922-0dd16fb68aea', IndividualTypeConceptSet),
	(gen_random_uuid(),'4297af86-e72d-4768-89c6-dfb9af9f84d0', IndividualTypeConceptSet),
	(gen_random_uuid(),'80ad8e8f-34c3-42bb-84d8-c59db8348bf7', PractitionerReferenceTypeConceptSet),
	(gen_random_uuid(),'77f1f45b-861f-4183-9f4f-e8529e45b38f', PractitionerReferenceTypeConceptSet),
	(gen_random_uuid(),'6b40d73f-5a20-4de3-9ef0-60bfab08d31e', PractitionerReferenceTypeConceptSet),
	(gen_random_uuid(), 'dfeab3cc-3d73-4d93-89a4-5db9753e1f9f', StatusConceptSet),
    (gen_random_uuid(), '946b7d3c-9c12-4bb8-9d3a-8f5b7e78d2f3', StatusConceptSet),
    (gen_random_uuid(), '72ef2b5e-8e25-473a-a78c-d3120f4c913a', StatusConceptSet),
    (gen_random_uuid(), 'a5b3e865-3c0b-4a4e-9b39-bdd8ff6c0cf7', StatusConceptSet),
    (gen_random_uuid(), '0cdd69f5-4b9b-403e-b8cb-d6a5af5f8203', StatusConceptSet),
    (gen_random_uuid(), '3a7958b4-8a4d-4d5b-8ff4-d78c8ab07e53', StatusConceptSet),
    (gen_random_uuid(), '28d51738-3a60-4a4e-8f5b-d61e5c7c1a79', StatusConceptSet),
	(gen_random_uuid(), 'bc1f6a17-4a4e-4f5b-9b39-c67f68c6d3f4', IntentConceptSet),
    (gen_random_uuid(), '26e5a784-8a6b-4f8b-9f5b-7e5f3a6b789a', IntentConceptSet),
    (gen_random_uuid(), 'e1f5d2b9-4c0b-4f5c-9d3a-6b5f5c7e3a8b', IntentConceptSet),
    (gen_random_uuid(), '9b3e6f5b-8a4d-4f8c-9b3a-8c7f5b3a6d1e', IntentConceptSet),
    (gen_random_uuid(), '58f6d1c8-4b9b-4f5a-9b3a-d5f3a5b8e4a7', IntentConceptSet),
    (gen_random_uuid(), 'd7a4b6c9-4c5b-4d5a-9f5b-7e5b8a6f7e3a', IntentConceptSet),
    (gen_random_uuid(), 'a8f5b7c8-4d5b-4f5a-9b3a-6d7f5e3a8b9c', IntentConceptSet),
    (gen_random_uuid(), 'c9e5d6f1-4b7b-4f5c-9b3a-8d7f5c6a3e5a', IntentConceptSet),
    (gen_random_uuid(), '8f5b7e6d-4f8b-4d5a-9b3a-7c5f3a8b6d1e', IntentConceptSet);


END $$;

