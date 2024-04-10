DO $$
DECLARE
    LanguageConceptSet UUID := '96944ce8-a8ff-4dfa-85e3-03d18c2988ed';
	AddressUseConceptSet UUID := '1bed378b-f5ef-48a1-9581-54a0ec544177';
	NameTypeConceptSet UUID := 'a16830e3-5d77-4457-8d6e-95d30fec9b83';
	ContactSystemConceptSet UUID := '19325dc3-3a65-4c1b-a475-e54ab519dab3';
	ContactPointUseConceptSet UUID := '9df86d35-0b98-4392-a4ac-dfb571140e1e';

BEGIN

-- Concept Sets
INSERT INTO public."ConceptSets"("Id", "Name")
VALUES 
		( LanguageConceptSet, 'Language'), 
		( AddressUseConceptSet,'AddressUse'), 
		( NameTypeConceptSet,'NameType'), 
		( ContactSystemConceptSet,'ContactSystem'), 
		( ContactPointUseConceptSet,'ContactPointUse');
	

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
    (gen_random_uuid(),'cffc025b-aacc-4681-a49c-a242507a3b6a', ContactSystemConceptSet);

END $$;


