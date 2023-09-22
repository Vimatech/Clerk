namespace Clerk.Webhooks;

/// <summary>
/// A collection of webhook events.
/// </summary>
public class WebhookEvent
{
    public class User
    {
        public string Created => "user.created";
        
        public string Updated => "user.updated";
        
        public string Deleted => "user.deleted";
    }
    
    public class Email
    {
        public string Created => "email.created";
    }

    public class Organization
    {
        public string Created => "organization.created";
        
        public string Updated => "organization.updated";
        
        public string Deleted => "organization.deleted";

        public class Domain
        {
            public string Created => "organizationDomain.created";
            
            public string Updated => "organizationDomain.updated";
            
            public string Deleted => "organizationDomain.deleted";
        }

        public class Invitation
        {
            public string Accepted => "organizationInvitation.accepted";
            
            public string Created => "organizationInvitation.created";
            
            public string Revoked => "organizationInvitation.revoked";
        }

        public class Membership
        {
            public string Created => "organizationMembership.created";
            
            public string Updated => "organizationMembership.updated";
            
            public string Deleted => "organizationMembership.deleted";
        }
    }

    public class Session
    {
        public string Created => "session.created";
        
        public string Ended => "session.ended";
        
        public string Removed => "session.removed";
        
        public string Revoked => "session.revoked";
    }

    public class Sms
    {
        public string Created => "sms.created";
    }
}