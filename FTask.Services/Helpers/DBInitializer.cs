using System.Collections.Generic;
using System;
using System.Linq;
using FTask.Database.Models;

namespace FTask.Services.Helpers
{
    public static class DBInitializer
    {
        public static void Initialize(FTaskContext context)
        {
            // Check database created
            context.Database.EnsureCreated();

            // Auto seed data if Majors have no data
            if (!context.Majors.Any())
            {
                var majors = new Major[]{
                    new Major{MajorId = "BIT_SE", MajorName = "Bachelor of Software engineer"},
                    new Major{MajorId = "BIT_IA", MajorName = "Bachelor of Information assurance"},
                    new Major{MajorId = "BBA_FIN", MajorName = "Business Administration Finance"},
                    new Major{MajorId = "BBA_IB", MajorName = "Business Administration International Business"},
                    new Major{MajorId = "BBA_MC", MajorName = "Business Administration Multimedia communication"},
                    new Major{MajorId = "BBA_MKT", MajorName = "Business Administration Marketing"},
                    new Major{MajorId = "BEL", MajorName = "Bachelor of English Language"},
                    new Major{MajorId = "BGD", MajorName = "Bachelor of Graphic Design"},
                    new Major{MajorId = "BJP", MajorName = "Bachelor of Japanese Language"},
                    new Major{MajorId = "BKR", MajorName = "Bachelor of Korean Language"},
                    new Major{MajorId = "BMC", MajorName = "Bachelor of Multimedia Communication"},
                };

                context.AddRange(majors);
                context.SaveChanges();

            }

            // Auto seed data if Semesters have no data
            if (!context.Semesters.Any())
            {
                var semesters = new Semester[]{
                    new Semester{SemesterId="FA_20",SemesterName="Fall 2020", StartDate=DateTime.Parse("2020-08-04T00:00:00"), EndDate=DateTime.Parse("2020-11-04T00:00:00"), IsComplete = true},
                    new Semester{SemesterId="SP_21",SemesterName="Spring 2021", StartDate=DateTime.Parse("2021-01-04T00:00:00"), EndDate=DateTime.Parse("2021-01-04T00:00:00"), IsComplete = true},
                    new Semester{SemesterId="SU_21",SemesterName="Summer 2021", StartDate=DateTime.Parse("2021-05-04T00:00:00"), EndDate=DateTime.Parse("2021-08-04T00:00:00"), IsComplete = false}
                };

                context.AddRange(semesters);
                context.SaveChanges();

            }

            // Auto seed data if Students have no data
            if (!context.Students.Any())
            {
                var students = new Student[]{
                    new Student{StudentId="SE111111", StudentName="Nguyen Van An", StudentEmail="AnnvSE111111@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE222222", StudentName="Nguyen Van Hai", StudentEmail="HainvSE222222@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE333333", StudentName="Nguyen Van Binh", StudentEmail="BinhnvSE333333@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE444444", StudentName="Nguyen Van Tai", StudentEmail="TainvSE444444@fpt.edu.vn", MajorId="BIT_SE"},
                    new Student{StudentId="SE555555", StudentName="Nguyen Van Ngan", StudentEmail="NgannvSE555555@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE666666", StudentName="Nguyen Van Son", StudentEmail="SonnvSE666666@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE777777", StudentName="Nguyen Thai Binh", StudentEmail="BinhntSE777777@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE888888", StudentName="Nguyen Van Thi", StudentEmail="ThinvSE888888@fpt.edu.vn", MajorId="BIT_IA"},
                    new Student{StudentId="SE999999", StudentName="Nguyen Van Quan", StudentEmail="QuannvSE999999@fpt.edu.vn", MajorId="BIT_IA"},
                };

                context.AddRange(students);
                context.SaveChanges();

            }

            // Auto seed data if SubjectGroup have no data
            if (!context.SubjectGroups.Any())
            {
                var subjectGroups = new SubjectGroup[]{
                    new SubjectGroup{SubjectGroupName = "Computing Fundamentals"},
                    new SubjectGroup{SubjectGroupName = "Software Engineering"},
                    new SubjectGroup{SubjectGroupName = "Politics"},
                    new SubjectGroup{SubjectGroupName = "Digital Art & Design"},
                    new SubjectGroup{SubjectGroupName = "Economics"},
                    new SubjectGroup{SubjectGroupName = "Finance"},
                    new SubjectGroup{SubjectGroupName = "General Management"},
                    new SubjectGroup{SubjectGroupName = "Information Assurance"},
                    new SubjectGroup{SubjectGroupName = "International Business"},
                    new SubjectGroup{SubjectGroupName = "Japanese"},
                    new SubjectGroup{SubjectGroupName = "Marketing"},
                    new SubjectGroup{SubjectGroupName = "Mathematics"},
                    new SubjectGroup{SubjectGroupName = "Accounting"},
                    new SubjectGroup{SubjectGroupName = "English"},
                    new SubjectGroup{SubjectGroupName = "Multiple Media Communication"},
                };

                context.AddRange(subjectGroups);
                context.SaveChanges();

            }

            // Auto seed data if Subjects have no data
            if (!context.Subjects.Any())
            {
                var subjects = new Subject[]{
                    new Subject{SubjectId="ISC301", SubjectName="E-Commerce", Source="...", SubjectGroupId=11},
                    new Subject{SubjectId="ACC101", SubjectName="Principles of Accounting", Source="Fundamental Accounting Principles, 20th Edition", SubjectGroupId=13},
                    new Subject{SubjectId="SWD391", SubjectName="Software Architecture and Design", Source="Software architecture design patterns in Java", SubjectGroupId=2},
                    new Subject{SubjectId="HCI201", SubjectName="Human-Computer Interaction", Source="...", SubjectGroupId=2},
                    new Subject{SubjectId="PRM391", SubjectName="Mobile Programming", Source="...", SubjectGroupId=2},
                };

                context.AddRange(subjects);
                context.SaveChanges();

            }

            // Auto seed data if Topics have no data
            if (!context.Topics.Any())
            {
                var topics = new Topic[]{
                    new Topic{TopicName="Chapter 01 Overview of Electronic Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 02 E-Commerce Mechanisms, Infrastructure, and Tools", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 03 Retailing in Electronic Commerce Products and Services", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 04 B2B E-Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 05 Innovative EC Systems From E-Government to E-Learning, Collaborative Commerce, and C2C Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 06 Mobile Commerce and Ubiquitous Computing", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 07 Social Commerce", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 08 Marketing-and-Advertising", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 09 E-Commerce-Security-and-Fraud-Protection", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 10 Electronic-Commerce-Payment-Systems", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 11 Order-Fulfillment-Along-the-Supply-Chain", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 12 EC-Strategy", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 13 Implementing EC Systems From Justification to Successful Performance", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 14 E-Commerce-Regulatory-Ethical-And-Social-Environments", TopicDescription="...", SubjectId="ISC301"},
                    new Topic{TopicName="Chapter 15 Launching a Successful Online Business and EC Projects", TopicDescription="...", SubjectId="ISC301"},

                    new Topic{TopicName="01 Accounting in Business", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="02 Analyzing and Recording Transactions", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="03 Adjusting Accounts and Preparing Financial Statements", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="04 Completing the Accounting Cycle", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="05 Accounting for Merchandising Operations", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="06 Inventories and Cost of Sales", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="07 Accounting Information Systems", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="08 Cash and Internal Controls", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="09 Accounting for Receivables", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="10 Plant Assets, Natural Resources, and Intangibles", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="11 Current Liabilities and Payroll Accounting", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="12 Accounting for Partnerships", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="13 Accounting for Corporations", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="14 Long-Term Liabilities", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="15 Investments and International Operations", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="16 Reporting the Statement of Cash Flows", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="17 Analysis of Financial Statements", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="18 Managerial Accounting Concepts and Principles", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="19 Job Order Cost Accounting", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="20 Process Cost Accounting", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="21 Cost Allocation and Performance Measurement", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="22 Cost-Volume-Profit Analysis", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="23 Master Budgets and Planning", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="24 Flexible Budgets and Standard Costs", TopicDescription="...", SubjectId="ACC101"},
                    new Topic{TopicName="25 Capital Budgeting and Managerial Decisions", TopicDescription="...", SubjectId="ACC101"},

                    new Topic{TopicName="CHAPTER 01. DESIGN PATTERNS: ORIGIN AND HISTORY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 02. UML: A QUICK REFERENCE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 03. INTERFACE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 04. ABSTRACT PARENT CLASS", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 05. PRIVATE METHODS", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 06. ACCESSOR METHODS", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 07. CONSTANT DATA MANAGER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 08. IMMUTABLE OBJECT", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 09. MONITOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 10. FACTORY METHOD", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 11. SINGLETON", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 12. ABSTRACT FACTORY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 13. PROTOTYPE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 14. BUILDER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 15. COMPOSITE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 16. ITERATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 17. FLYWEIGHT", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 18. VISITOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 19. DECORATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 20. ADAPTER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 21. CHAIN OF RESPONSIBILITY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 22. FAÇADE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 23. PROXY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 24. BRIDGE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 25. VIRTUAL PROXY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 26. COUNTING PROXY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 27. AGGREGATE ENFORCER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 28. EXPLICIT OBJECT RELEASE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 29. OBJECT CACHE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 30. COMMAND", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 31. MEDIATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 32. MEMENTO", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 33. OBSERVER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 34. INTERPRETER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 35. STATE", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 36. STRATEGY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 37. NULL OBJECT", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 38. TEMPLATE METHOD", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 39. OBJECT AUTHENTICATOR", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 40. COMMON ATTRIBUTE REGISTRY", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 41. CRITICAL SECTION", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 42. CONSISTENT LOCK ORDER", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 43. GUARDED SUSPENSION", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 44. READ-WRITE LOCK", TopicDescription="...", SubjectId="SWD391"},
                    new Topic{TopicName="CHAPTER 45. CASE STUDY: A WEB HOSTING COMPANY", TopicDescription="...", SubjectId="SWD391"},

                    new Topic{TopicName="Chapter 01: What is interaction design?", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 02: Understanding and conceptualizing interaction", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 03: Understanding users", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 04: Designing for collaboration and communication", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 05: Affective aspects", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 06: Interfaces and interactions", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 07: Data gathering", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 08: Data analysis, interpretation and presentation", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 09: The process of interaction design", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 10: Identifying needs and establishing requirements", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 11: Design, prototyping and construction", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 12: Introducing Evaluation", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 13: An evaluation framework", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 14: Usability testing and field studies", TopicDescription="...", SubjectId="HCI201"},
                    new Topic{TopicName="Chapter 15: Analytical evaluation", TopicDescription="...", SubjectId="HCI201"},

                    new Topic{TopicName="01. Overview", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="02. Activities_Intents", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="03. AndroidUI", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="04. DynamicUI", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="05. UINotification", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="06. PicturesMenu", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="07. DataPersistent", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="08. DB", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="09. Message_LocalServices", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="10. Android Hardware", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="11. Publish_HTML5", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="12. PhoneGap", TopicDescription="...", SubjectId="PRM391"},
                    new Topic{TopicName="13. SenchaTouch", TopicDescription="...", SubjectId="PRM391"},
                };

                context.AddRange(topics);
                context.SaveChanges();

            }

            // Auto seed data if TaskCategories have no data
            if (!context.TaskCategories.Any())
            {
                var taskCategories = new TaskCategory[]{
                    new TaskCategory{TaskType="Self study"},
                    new TaskCategory{TaskType="Exercise / Homework"},
                    new TaskCategory{TaskType="Quiz"},
                    new TaskCategory{TaskType="Assignment / Project"},
                };

                context.AddRange(taskCategories);
                context.SaveChanges();

            }

            // Auto seed data if PlanSemester have no data
            if (!context.PlanSemesters.Any())
            {
                var planSemesters = new PlanSemester[]{
                    new PlanSemester{
                        PlanSemesterName="Happy and pass!",
                        StudentId="SE111111",
                        SemesterId="SU_21",
                        CreateDate=DateTime.UtcNow.AddHours(7),
                        IsComplete=false
                    },
                };

                context.AddRange(planSemesters);
                context.SaveChanges();
            }

            // Auto seed data if PlanSubject have no data
            if (!context.PlanSubjects.Any())
            {
                var planSubjects = new PlanSubject[]{
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "ISC301"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "ACC101"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "SWD391"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "HCI201"
                    },
                    new PlanSubject{
                        Priority = 0,
                        Progress = 0,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        IsComplete = false,
                        PlanSemesterId = 1,
                        SubjectId = "PRM391"
                    },
                };

                context.AddRange(planSubjects);
                context.SaveChanges();
            }

            // Auto seed data if PlanTopic have no data
            if (!context.PlanTopics.Any())
            {
                List<PlanTopic> planTopics = new List<PlanTopic>();

                var planSubject1 = context.PlanSubjects.Where(x => x.PlanSubjectId == 1).FirstOrDefault();
                
                var subject1 = context.Subjects.Where(x => x.SubjectId == planSubject1.SubjectId).FirstOrDefault();

                var topics1 = context.Topics.Where(x => x.SubjectId == subject1.SubjectId).ToArray().OrderBy(x => x.TopicName);
                
                var planSubject2 = context.PlanSubjects.Where(x => x.PlanSubjectId == 2).FirstOrDefault();
                
                var subject2 = context.Subjects.Where(x => x.SubjectId == planSubject2.SubjectId).FirstOrDefault();

                var topics2 = context.Topics.Where(x => x.SubjectId == subject2.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject3 = context.PlanSubjects.Where(x => x.PlanSubjectId == 3).FirstOrDefault();
                
                var subject3 = context.Subjects.Where(x => x.SubjectId == planSubject3.SubjectId).FirstOrDefault();

                var topics3 = context.Topics.Where(x => x.SubjectId == subject3.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject4 = context.PlanSubjects.Where(x => x.PlanSubjectId == 4).FirstOrDefault();
                
                var subject4 = context.Subjects.Where(x => x.SubjectId == planSubject4.SubjectId).FirstOrDefault();

                var topics4 = context.Topics.Where(x => x.SubjectId == subject4.SubjectId).ToArray().OrderBy(x => x.TopicName);

                var planSubject5 = context.PlanSubjects.Where(x => x.PlanSubjectId == 5).FirstOrDefault();
                
                var subject5 = context.Subjects.Where(x => x.SubjectId == planSubject5.SubjectId).FirstOrDefault();

                var topics5 = context.Topics.Where(x => x.SubjectId == subject5.SubjectId).ToArray().OrderBy(x => x.TopicName);                

                if(planSubject1 is not null){
                    foreach (var item in topics1)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject1.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }                 

                if(planSubject2 is not null){
                    foreach (var item in topics2)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject2.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject3 is not null){
                    foreach (var item in topics3)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject3.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                if(planSubject4 is not null){
                    foreach (var item in topics4)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject4.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                } 

                if(planSubject5 is not null){
                    foreach (var item in topics5)
                    {
                        var planTopic = new PlanTopic{
                            Progress = 0,
                            IsComplete = false,
                            TopicId = item.TopicId,
                            PlanSubjectId = planSubject5.PlanSubjectId
                        };

                        planTopics.Add(planTopic);
                    }
                }

                context.AddRange(planTopics);
                context.SaveChanges();

            }

            // Auto seed data if Task have no data
            if (!context.Tasks.Any()){
                var plantopics = context.PlanTopics.ToArray();

                List<Task> tasks = new List<Task>();

                foreach (var item in plantopics)
                {
                    var task1 = new Task{
                        TaskDescription = "Read at home " + item.Topic.TopicName,
                        CreateDate = DateTime.UtcNow.AddHours(7),
                        EstimateTime = 2,
                        EffortTime = 1,
                        DueDate = DateTime.UtcNow.AddHours(10),
                        Priority = 0,
                        IsComplete = false,
                        PlanTopicId = item.PlanTopicId,
                        TaskCategoryId = 1
                    };

                    var task2 = new Task{
                        TaskDescription = "Do exercise of " + item.Topic.TopicName,
                        CreateDate = DateTime.UtcNow.AddHours(11),
                        EstimateTime = 2,
                        EffortTime = 1,
                        DueDate = DateTime.UtcNow.AddHours(14),
                        Priority = 0,
                        IsComplete = false,
                        PlanTopicId = item.PlanTopicId,
                        TaskCategoryId = 1
                    };

                    var task3 = new Task{
                        TaskDescription = "Make quiz of " + item.Topic.TopicName,
                        CreateDate = DateTime.UtcNow.AddHours(15),
                        EstimateTime = 2,
                        EffortTime = 1,
                        DueDate = DateTime.UtcNow.AddHours(19),
                        Priority = 1,
                        IsComplete = false,
                        PlanTopicId = item.PlanTopicId,
                        TaskCategoryId = 1
                    };

                    tasks.Add(task1);
                    tasks.Add(task2);
                    tasks.Add(task3);
                }

                context.AddRange(tasks);
                context.SaveChanges();
            }
        }
    }
}
