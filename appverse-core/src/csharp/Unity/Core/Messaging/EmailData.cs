/*
 Copyright (c) 2012 GFT Appverse, S.L., Sociedad Unipersonal.

 This Source  Code Form  is subject to the  terms of  the Appverse Public License 
 Version 2.0  (“APL v2.0”).  If a copy of  the APL  was not  distributed with this 
 file, You can obtain one at http://appverse.org/legal/appverse-license/.

 Redistribution and use in  source and binary forms, with or without modification, 
 are permitted provided that the  conditions  of the  AppVerse Public License v2.0 
 are met.

 THIS SOFTWARE IS PROVIDED BY THE  COPYRIGHT HOLDERS  AND CONTRIBUTORS "AS IS" AND
 ANY EXPRESS  OR IMPLIED WARRANTIES, INCLUDING, BUT  NOT LIMITED TO,   THE IMPLIED
 WARRANTIES   OF  MERCHANTABILITY   AND   FITNESS   FOR A PARTICULAR  PURPOSE  ARE
 DISCLAIMED. EXCEPT IN CASE OF WILLFUL MISCONDUCT OR GROSS NEGLIGENCE, IN NO EVENT
 SHALL THE  COPYRIGHT OWNER  OR  CONTRIBUTORS  BE LIABLE FOR ANY DIRECT, INDIRECT,
 INCIDENTAL,  SPECIAL,   EXEMPLARY,  OR CONSEQUENTIAL DAMAGES  (INCLUDING, BUT NOT
 LIMITED TO,  PROCUREMENT OF SUBSTITUTE  GOODS OR SERVICES;  LOSS OF USE, DATA, OR
 PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
 WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT(INCLUDING NEGLIGENCE OR OTHERWISE) 
 ARISING  IN  ANY WAY OUT  OF THE USE  OF THIS  SOFTWARE,  EVEN  IF ADVISED OF THE 
 POSSIBILITY OF SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace Unity.Core.Messaging
{
	public class EmailData
	{
		/// <summary>
		/// Parameterless constructor is needed when parsing jsonstring to object.
		/// </summary>
		public EmailData ()
		{
		}

		public string Subject { get; set; }

		public EmailAddress FromAddress { get; set; }

		public EmailAddress[] ToRecipients { get; set; }

		public EmailAddress[] CcRecipients { get; set; }

		public EmailAddress[] BccRecipients { get; set; }

		public string MessageBodyMimeType { get; set; }

		public string MessageBody { get; set; }

		public AttachmentData[] Attachment { get; set; }

		public string[] ToRecipientsAsString {
			get {
				return EmailAddressToStringArray (ToRecipients);
			}
		}

		public string[] CcRecipientsAsString {
			get {
				return EmailAddressToStringArray (CcRecipients);
			}
		}

		public string[] BccRecipientsAsString {
			get {
				return EmailAddressToStringArray (BccRecipients);
			}
		}

		private static string[] EmailAddressToStringArray (EmailAddress[] addressees)
		{
			EmailAddress[] emailAddresses = addressees;
			if (emailAddresses != null && emailAddresses.Length > 0) {
				string[] addresses = new string[emailAddresses.Length];
				for (int i = 0; i < emailAddresses.Length; i++) {
					if (emailAddresses [i].CommonName != null) {
						// "standard" address format
						addresses [i] = "\"" + emailAddresses [i].CommonName + "\" <" + emailAddresses [i].Address + ">";
					} else {
						addresses [i] = emailAddresses [i].Address;
					}
				}
				return addresses;
			} else {
				return new string[0];
			}		
		}
	}
}
